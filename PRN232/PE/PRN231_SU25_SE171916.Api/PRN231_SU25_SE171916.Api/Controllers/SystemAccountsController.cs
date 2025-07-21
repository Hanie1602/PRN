using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PRN231_SU25_SE171916.Repositories.Models;
using PRN231_SU25_SE171916.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PRN231_SU25_SE171916.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SystemAccountsController : ControllerBase
	{
		private readonly IConfiguration _config;
		private readonly SystemAccountService _systemAccountService;

		public SystemAccountsController(IConfiguration config, SystemAccountService systemAccountService)
		{
			_config = config;
			_systemAccountService = systemAccountService;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest request)
		{
			var user = await _systemAccountService.GetUserAccount(request.Email, request.Password);

			if (user == null)
				return Unauthorized();

			var token = GenerateJSONWebToken(user);
			var role = "";
			switch (user.Role)
			{
				case 1: role = "administrator"; break;
				case 2: role = "moderator"; break;
				case 3: role = "developer"; break;
				case 4: role = "member"; break;
				default: role = ""; break;
			}

			return Ok(new { Token = token, Role = role });
		}

		private string GenerateJSONWebToken(SystemAccount systemAccount)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(_config["Jwt:Issuer"]
					, _config["Jwt:Audience"]
					, new Claim[]
					{
				new(ClaimTypes.Email, systemAccount.Email),
				new(ClaimTypes.Role, systemAccount.Role.ToString()),
					},
					expires: DateTime.Now.AddMinutes(120),
					signingCredentials: credentials
				);

			var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

			return tokenString;
		}

		public sealed record LoginRequest(string Email, string Password);
	}
}
