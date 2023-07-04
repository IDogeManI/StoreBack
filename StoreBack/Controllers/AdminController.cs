using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreBack.Models;
using StoreBack.Services;
using System.IdentityModel.Tokens.Jwt;

namespace StoreBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly JwtHandler _jwtHandler;
        private readonly AdminsService _adminsService;
        public AdminController(JwtHandler jwtHandler, AdminsService adminsService)
        {
            _jwtHandler = jwtHandler;
            _adminsService = adminsService;

        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = _adminsService.GetAdminByEmail(userForAuthentication.Email);

            if (user == null || !_adminsService.CheckPasswordForAdmin(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }
        [Authorize]
        [HttpGet]
        public string Get()
        {
            return "Success";
        }
        
    }
}
