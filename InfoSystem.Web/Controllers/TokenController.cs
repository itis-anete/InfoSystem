using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ServicesMonitoringSystem.Web.Models;

namespace InfoSystem.Web.Controllers
{
    /// <summary>
    /// Used to give tokens
    /// </summary>
    public class TokenController : Controller
    {
        /// <summary>
        /// Used to receive new JWT.
        /// </summary>
        /// <returns>JWT in string format, example : Bearer *token*</returns>
        [HttpGet]
        public string GetToken()
        {
            var identity = GetIdentity();
            if (identity == null)
            {
                Response.StatusCode = 400;
                return "";
            }

            var key = AuthentificationOptions.GetSymmetricSecurityKey();
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                AuthentificationOptions.Issuer,
                AuthentificationOptions.Audience,
                identity.Claims,
                now,
                now.AddMinutes(1),
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            return "Bearer " + new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private ClaimsIdentity GetIdentity()
        {
            var person = new Person() {Login = "admin", Password = "admin"};
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login)
            };
            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}