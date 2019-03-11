using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Net.Http.Headers;

namespace InfoSystem.Web
{
	/// <inheritdoc cref="IAuthorizationFilter" />
	public class AuthenticateAttribute : Attribute, IAuthorizationFilter
	{
		/// <inheritdoc />
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			try
			{
				var token = context.HttpContext.Request.Headers[HeaderNames.Authorization];
				if (!token.StartsWith(new[] {"Bearer"}))
					throw new AuthenticationException("Not Bearer authentification!");
				token = token.ToString().Substring("Bearer".Length + 1);
				var readJwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
				if (readJwtToken.ValidTo < DateTime.UtcNow)
					throw new AuthenticationException("Token expired");
				context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(readJwtToken.Claims));
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw new AuthenticationException("Auth fail", e);
			}
		}
	}
}