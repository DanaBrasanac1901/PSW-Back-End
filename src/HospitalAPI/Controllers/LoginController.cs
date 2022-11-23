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

namespace HospitalAPI.Controllers
{
    public class LoginController : Controller
    {
		private IConfiguration _config;
		private IUserService _userService;

		public LoginController(IConfiguration config, IUserService userService)
		{
			_config = config;
			_userService = userService;
		}

		[AllowAnonymous] //prevent the auth process to happen when calling

		[HttpPost]
		public IActionResult Login([FromBody] User user)
		{
			var _user = Authenticate(user);
			if (_user != null)
			{
				var token = Generate(_user);
				return Ok(token);
			}

			return NotFound();
		}

		private string Generate(User user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			//HmacSha256 - hashing algorithm

			var claims = new[] //a way to store the data so that you don't have to always access the db
			{ //these are set-in-stone claims (NameIdentifier, Email, GivenName)
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
