using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyPortal.API.Mapping;
using MyPortal.Entity.DTO;
using MyPortal.Services.Interfaces;
using Serilog;

namespace MyPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuth repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }
        [HttpPost("Login")]
        public async Task <IActionResult> Login(UserForLogin userForLoginDto)
        {
            //throw new NullReferenceException("computer says no to null.");
            Log.Information("Login action invoked");
            Log.Information("User " + userForLoginDto.Username +  " attempting to login");
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);
            if (userFromRepo == null)
            {
                Log.Information("User " + userForLoginDto.Username + " logged in failed");
                return Unauthorized();
            }
            Log.Information("User " + userFromRepo.Firstname + " logged in successful");
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name ,userFromRepo.Username )
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var result = new JwtSecurityTokenHandler().WriteToken(token);
            UserProfile userProfileDto = await ProfileMapper.ProfileDtoMapper(result, userFromRepo);
            return Ok(userProfileDto);
        }
        
   
      
    }
}
