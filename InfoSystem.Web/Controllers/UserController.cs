using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using InfoSystem.Core.Entities;
using InfoSystem.Sockets.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InfoSystem.Web.Controllers
{
    /// <summary>
    /// Used to manage user accounts
    /// </summary>
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserDomainService _service;

        /// <inheritdoc />
        public UserController(UserDomainService service)
        {
            _service = service;
        }

        /// <summary>
        /// Used to log in and receive new JWT.
        /// </summary>
        /// <returns>JWT ready for header format, example : Bearer *token*</returns>
        [HttpGet]
        public IActionResult LogIn(string login, string password)
        {
            if (!_service.Verify(login, password))
                return StatusCode(500, "Incorrect user credentials!");

            var identity = GetIdentity(login);
            if (identity == null)
                return StatusCode(500);

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
            return Ok("Bearer " + token);
        }

        [HttpPost]
        public User Register(string login, string password)
        {
            return _service.Register(login, password);
        }


        private ClaimsIdentity GetIdentity(string login)
        {
            var user = _service.Get(login);
            var claims = new List<Claim>
            {
                new Claim("Name", user.Login)
            };
            if (user.Role != null)
                claims.Add(new Claim("Role", user.Role.Name));

            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}