using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.Dto.Concrete;
using Project.OnlineQA.Entities.Concrete;

namespace Project.OnlineQA.WebApi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public LoginController(IUserService userService, IMapper mapper,IConfiguration config)
        {
            _userService = userService;
            _mapper = mapper;
            _config = config;

        }
        [HttpPost]
        public async Task<IActionResult> Login(string username,string password/*[FromQuery] LoginDto loginDto*/)
        {
            User user=await _userService.GetByUserName(username);
            IActionResult response = Unauthorized();
            if (user == null)
            {
                return BadRequest("No user was found");
            }
            
            else
            {
                if (user.Password == password)
                {
                    var tokenStr = GenerateJSONWebToken(user);
                    response = Ok(new { token = tokenStr });
                }
                else
                {
                    response = BadRequest("Incorrect password!");
                }
               
            }
            
            return response;

        }
        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        
        
    }
}
