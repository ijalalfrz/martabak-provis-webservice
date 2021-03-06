﻿using System;
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
            try
            {
                var user = Authenticate(login);

                if (user != null)
                {
                    var tokenString = BuildToken(user);
                    user.password = "";
                    response = Ok(new
                    {
                        token = tokenString.token,
                        expire = tokenString.expires,
                        user.id_toko,
                        user.id_user,
                        user.nama,
                        user.password,
                        user.role,
                        user.username
                    });
                }


                return response;
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = e.Message
                });
            }


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

        private TokenModel BuildToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            DateTime expire = DateTime.Now.AddDays(30);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: expire,
              signingCredentials: creds);
            TokenModel data = new TokenModel();
            data.token = new JwtSecurityTokenHandler().WriteToken(token);
            data.expires = expire;

            return data;
    }

        private class TokenModel
        {
            public string token { get; set; }
            public DateTime expires { get; set; }
        }

    }
}