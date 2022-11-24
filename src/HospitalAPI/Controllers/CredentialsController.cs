using HospitalLibrary.Core.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

		public CredentialsController(IConfiguration config, IUserService userService)
		{
			_config = config;
			_userService = userService;
			tokenHandler=new JwtSecurityTokenHandler();

		}

		[AllowAnonymous] //prevent the auth process to happen when calling

		[HttpPost("login")]
		public IActionResult Login([FromBody] User user)
		{
			
			var _user = Authenticate(user);
			if (_user != null)
			{
				var token = Generate(_user);
				return Ok( tokenHandler.ReadToken(token));
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

		private User Authenticate(User user)
		{
			// UserConstraints -> baza
			var users = _userService.GetAll();
			var currentUser = users.FirstOrDefault(o => o.Email.ToLower() ==
				 user.Email.ToLower() && o.Password == user.Password);


			if (currentUser != null) return currentUser;
			return null;

		}
	}
}
