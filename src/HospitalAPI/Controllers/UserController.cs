using HospitalLibrary.Core.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace HospitalAPI.Controllers
{
    public class UserController : ControllerBase
    {
		private readonly IUserService _userService;


		public UserController(IUserService userService)
		{
			_userService = userService;
		}
		[HttpGet("Doctors")]
		[Authorize(Roles = "DOCTOR")]
		public IActionResult DoctorsEndpoint()
		{
			var currentUser = GetCurrentUser();
			return Ok($"Hi {currentUser.Name}, you are an {currentUser.Role}");
		}

		[HttpGet("Patients")]
		[Authorize(Roles = "PATIENT")]
		public IActionResult PatientsEndpoint()
		{
			var currentUser = GetCurrentUser();
			return Ok($"Hi {currentUser.Name}, you are an {currentUser.Role}");
		}

		private User GetCurrentUser()
		{
			var identity = HttpContext.User.Identity as ClaimsIdentity;

			if (identity != null)
			{
				var userClaims = identity.Claims;
                try
                {
					int id = int.Parse(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Sid)?.Value);
				}
				catch(InvalidCastException e)
                {
					return null;
                }

				return new User
				{
					Id = int.Parse(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Sid)?.Value),
					Name = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
					Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
					Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
					Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value


				};
			}
			return null;
		}
	}
}
