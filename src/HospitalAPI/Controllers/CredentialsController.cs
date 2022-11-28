using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Patient;
using HospitalLibrary.Core.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using static System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler;

namespace HospitalAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CredentialsController : ControllerBase
    {

		private IConfiguration _config;
		private IUserService _userService;
		private JwtSecurityTokenHandler tokenHandler;
		private IEmailSendService _emailSendService;

		public CredentialsController(IConfiguration config, IUserService userService, IEmailSendService emailSendService)
		{
			_config = config;
			_userService = userService;
			tokenHandler=new JwtSecurityTokenHandler();
			_emailSendService = emailSendService;
		}

		[AllowAnonymous] //prevent the auth process to happen when calling

		[HttpPost("login")]
		public IActionResult Login([FromBody] User user)
		{
			
			var _user = _userService.Authenticate(user);
			if (_user != null)
			{
				var token = Generate(_user);
				return Ok(tokenHandler.ReadToken(token));
			}

			return Unauthorized();
		}

		private string Generate(User user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			//HmacSha256 - hashing algorithm

			
			var claims = new[] //a way to store the data so that you don't have to always access the db
			{ //these are set-in-stone claims (NameIdentifier, Email, GivenName)
				new Claim(ClaimTypes.Sid, user.Id.ToString()), 
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.GivenName, user.Name),
				new Claim(ClaimTypes.Surname, user.Surname),
				new Claim(ClaimTypes.Role, user.Role)
};
			var token = new JwtSecurityToken(_config["Jwt:Issuer"],
				_config["Jwt:Audience"],
				claims,
				expires: DateTime.Now.AddMinutes(15),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}


		[HttpPost("send-activation")]
		public ActionResult SendActivationCode(string email)
		{
			if (ModelState.IsValid)
			{
				var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
				var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
				User user = _userService.GetByEmail(email);
				if (user != null)
				{
					//string To = email, UserID, Password, SMTPPort, Host;
					var claims = new[] { //a way to store the data so that you don't have to always access the db
										 //these are set-in-stone claims (NameIdentifier, Email, GivenName)
						new Claim(ClaimTypes.NameIdentifier, user.Name),
						new Claim(ClaimTypes.Email, user.Email),
						new Claim(ClaimTypes.GivenName, user.Name),
						new Claim(ClaimTypes.Surname, user.Surname),
						new Claim(ClaimTypes.Role, user.Role)
					};
					var token = new JwtSecurityToken(_config["Jwt:Issuer"],
						_config["Jwt:Audience"],
						claims,
						expires: DateTime.Now.AddMinutes(15),
						signingCredentials: credentials);
					if (token == null)
					{
						// If user does not exist or is not confirmed.
						//return View("Index");
					}
					else
					{
						//Create URL with above token
						var lnkHref = Url.Action("Activate", "Credentials", new { email = email, code = token }, "http");
						//HTML Template for Send email
						string subject = "Activation";
						string body = "Your activation link: " + lnkHref;
						//Get and set the AppSettings using configuration manager.
						_emailSendService.SendEmail(new Message(new string[] { email, "docatufe@hotmail.com" }, "Activation", body));
						//Call send email methods.
						return Ok();
					}
				}
			}
			return NotFound();
		}

        [HttpGet("activate-account")]
		public ActionResult Activate()
		{
            StringValues headerValues;
			//  var email = string.Empty;
			// Request.Headers.TryGetValue("email",out headerValues);
			// email = headerValues.FirstOrDefault();
			string email = Request.Query["email"];
            if (ModelState.IsValid)
            {
                bool response = _userService.Activate(_userService.GetByEmail(email));
                if (response)
                {
                    return Ok("Successfully Changed");
                }
                else
                {
					return NotFound("Something went horribly wrong!");
                }
            }
			return BadRequest();
        }
    }
}
