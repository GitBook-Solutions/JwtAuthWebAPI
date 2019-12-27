using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtModels;
namespace JwtAuthWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration  _config;
        private IUserService  _userService;
        public TokenController(IConfiguration config,IUserService userService)
        {
            _config=config;
            _userService=userService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]AuthenticateModel userDto)
        {
            IActionResult response = Unauthorized();
            var user = _userService.Authenticate(userDto.Username, userDto.Password);
            if (user == null)
               return BadRequest(new { message = "Username or password is incorrect" });
            if(user!=null)
            {
                var tokenString = BuildToken();
                response = Ok(new {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = tokenString
                });
            }
            return response;
        }

        private string BuildToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);
            return tokenHandler.WriteToken(token);
        }
    }
}
