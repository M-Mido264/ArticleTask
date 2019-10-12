using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ArticleTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ArticleTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private  UserManager<AppUser> userManager;
        private readonly ApplicationSettings _applicationSettings;

        public UserController(UserManager<AppUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            this.userManager = userManager;
            _applicationSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
        //http://localhost:50357/api/user/register
        public async Task<Object> UserRegistration(RegisterModel userModel)
        {
            var user = new AppUser()
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                FullName = userModel.FullName
            };
            try
            {
                var result = await userManager.CreateAsync(user, userModel.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //http://localhost:50357/api/user/login
        public async Task<IActionResult> UserLogin(LoginModel userModel)
        {
            var user = await userManager.FindByNameAsync(userModel.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, userModel.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSettings.JWT_Secret)),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "username or passsword not correct!" });
            }
        }
    
}
}