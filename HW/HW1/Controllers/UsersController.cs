using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		[HttpGet]
		public ActionResult<List<string>> GetAll()
		{
			return Ok(StaticDb.Users);
		}

		[HttpGet("{index}")]
		public ActionResult<string> GetUserByIndex(int index)
		{
			try
			{
				if(index < 0)
				{
					return StatusCode(StatusCodes.Status400BadRequest, "The index is a negative number");
				}

				if(index >= StaticDb.Users.Count)
				{
					return StatusCode(StatusCodes.Status404NotFound, $"The user with index {index} was not found.");
				}

				return Ok(StaticDb.Users[index]);
			}
			catch(Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. Contact the support team.");
			}
		}
	}
}
