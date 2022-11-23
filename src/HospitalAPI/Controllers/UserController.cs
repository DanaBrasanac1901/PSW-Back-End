using HospitalLibrary.Core.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace HospitalAPI.Controllers
{
    public class UserController : Controller
    {
		[HttpGet("Doctors")]
		[Authorize(Roles = "Doctor")]
		public IActionResult DoctorsEndpoint()
		{
			var currentUser = GetCurrentUser();
			return Ok($"Hi {currentUser.Name}, you are an {currentUser.Role}");
		}

		[HttpGet("Patients")]
		[Authorize(Roles = "Patient")]
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

				return new User
				{
					//Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
					Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
					Name = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
					Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
					Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value


				};
			}
			return null;
		}
	}
}
