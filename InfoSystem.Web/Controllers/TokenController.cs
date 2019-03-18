using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InfoSystem.Web.Controllers
{
    /// <summary>
    /// Used to give tokens
    /// </summary>
    [Route("[controller]/[action]")]
    public class TokenController : Controller
    {
        /// <summary>
        /// Used to receive new JWT.
        /// </summary>
        /// <returns>JWT ready for header format, example : Bearer *token*</returns>
        [HttpGet]
        [AllowAnonymous]
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
                now.AddMinutes(AuthentificationOptions.Lifetime),
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return "Bearer " + token;
        }

        private ClaimsIdentity GetIdentity()
        {
            var person = new Person() {Login = "admin", Password = "admin", Role = "admin"};
            var claims = new List<Claim>
            {
                new Claim("Name", person.Login),
                new Claim("Role", person.Role)
            };
            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}