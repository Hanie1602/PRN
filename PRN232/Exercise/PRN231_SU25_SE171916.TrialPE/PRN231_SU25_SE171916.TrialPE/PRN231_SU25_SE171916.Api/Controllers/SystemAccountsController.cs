﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _systemAccountService.GetUserAccount(request.UserName, request.Password);

            if (user == null || user.Result == null)
                return Unauthorized();

            var token = GenerateJSONWebToken(user.Result);

            return Ok(token);
        }

        private string GenerateJSONWebToken(SystemAccount systemUserAccount)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"]
                    , _config["Jwt:Audience"]
                    , new Claim[]
                    {
                new(ClaimTypes.Email, systemUserAccount.Email),
                new(ClaimTypes.Role, systemUserAccount.Role.ToString()),
                    },
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        public sealed record LoginRequest(string UserName, string Password);
    }
}
