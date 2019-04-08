using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using InfoSystem.Sockets.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace InfoSystem.Web
{
	public static class StartupExtensions
	{
		public static void AddInfrastructure(this IServiceCollection services)
		{
			services.AddScoped<IEntityRepository, EntityRepository>();
			services.AddScoped<IPropertyRepository, PropertyRepository>();
			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<ITypeRepository, TypeRepository>();
			services.AddScoped<IUserRepository, UserRepository>();

			services.AddScoped<EntityDomainService>();
			services.AddScoped<RoleDomainService>();
			services.AddScoped<TypeDomainService>();
			services.AddScoped<PropertyDomainService>();
			services.AddScoped<UserDomainService>();

			services.AddScoped<InfoSystemDbContext>();
		}

		public static void AddJwtAuthentication(this IServiceCollection services)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidIssuer = AuthentificationOptions.Issuer,
					ValidateAudience = true,
					ValidAudience = AuthentificationOptions.Audience,
					ValidateLifetime = true,
					IssuerSigningKey = AuthentificationOptions.GetSymmetricSecurityKey(),
					ValidateIssuerSigningKey = true,
				};
			});
		}
	}
}