using Microsoft.AspNetCore.Mvc;
using PRN231_SU25_SE171916.Api.DTO;

namespace PRN231_SU25_SE171916.Api.Controllers
{
	[ApiController]
	public class BaseController : ControllerBase
	{
		protected IActionResult Error(string errorCode, string message, int statusCode)
		{
			return StatusCode(statusCode, new ErrorResponse
			{
				ErrorCode = errorCode,
				Message = message
			});
		}
	}
}
