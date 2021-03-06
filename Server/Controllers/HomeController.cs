﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()

        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "some_id"),
                new Claim("granny", "cookie")
            };

            var secretBytes = Encoding.UTF8.GetBytes(Constants.Secret); //Encode the secret we defined in that Constants.cs 
            var key = new SymmetricSecurityKey(secretBytes); //set the key here
            var algorithm = SecurityAlgorithms.HmacSha256; //choose the algorithm 
            
            var signingCredentials = new SigningCredentials(key, algorithm);
            
            
            //here we want to create the token 

            var token = new JwtSecurityToken(
                Constants.Issuer,
                Constants.Audience,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signingCredentials);

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new {access_token = tokenJson });
        }    
        
        public IActionResult Decode(string part)
        {
            var bytes= Convert.FromBase64String(part);
            return Ok(Encoding.UTF8.GetString(bytes));
        }

    }
}