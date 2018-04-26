using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MartabakProvis.Helper;
using MartabakProvis.Models;
using MartabakProvis.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MartabakProvis.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private IConfiguration _config;
        private UserRepo userRepo;

        public TokenController(IConfiguration config)
        {
            _config = config;
            userRepo = new UserRepo();
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                user.password = "";
                response = Ok(new {
                    token = tokenString,
                    data = new
                    {
                        user = user
                    }
                });
            }

            return response;
        }

        private UserModel Authenticate(LoginModel login)
        {
            UserModel user = null;
            var find = userRepo.GetByUsername(login.Username);
            if (find != null)
            {
                user = find;
                if (Util.ValidateSHA1HashData(login.Password, user.password))
                {

                    return user;
                }
            }
            return null;
        }

        private string BuildToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddDays(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}