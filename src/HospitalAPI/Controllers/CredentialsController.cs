using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;

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

		

		[AllowAnonymous]
		[HttpPost("send-activation")]
		public ActionResult SendActivationCode(RegisterDTO regDTO)
		{

			if (!ModelState.IsValid) return BadRequest();

			string email = regDTO.Email;
			var token = _userService.GenerateActivationToken(email);
			
			if (token!=null)
			{
				_userService.SaveTokenToDatabase(email, token);

				var lnkHref = Url.Action("Activate", "Credentials", new { email = email, code = token }, "http");
				string subject = "HealthcareMD Activation Link";
				string body = "Your activation link: " + lnkHref;
				_emailSendService.SendEmail(new Message(new string[] { email, "tibbers707@gmail.com" }, subject, body));
				return Ok();
			}

			return NotFound();
		}

        [HttpGet("activate-account")]
		public ActionResult Activate()
		{
			string email = Request.Query["email"];
			string token = Request.Query["code"];


			if (ModelState.IsValid)
            {
                bool response = _userService.Activate(email,token);
				
                if (response)
                {
                    return Ok(token);
                }
                else
                {
					return NotFound("Something went wrong!");
                }
            }
			return BadRequest();
        }


		private string Generate(User user)
		{
			var token=_userService.GenerateFullToken(user);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
    }
}
