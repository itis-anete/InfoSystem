using System;
using System.IO;
using System.Reflection;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using InfoSystem.Sockets.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace InfoSystem.Web
{
	/// <summary>
	/// Web configuration class.
	/// </summary>
	public class Startup
	{
		/// <inheritdoc />
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// Application configuration.
		/// </summary>
		public IConfiguration Configuration { get; }

		///<summary>This method gets called by the runtime. Use this method to add services to the container.</summary> 
		public void ConfigureServices(IServiceCollection services)
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
			
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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
			
			services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "InfoSystem API",
					Version = "v1",
					Description = "This is InfoSystem"
				});
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				options.IncludeXmlComments(xmlPath);
			});
		}

		///<summary>This method gets called by the runtime. Use this method to configure the HTTP request pipeline.</summary>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseStaticFiles();
			app.UseSpaStaticFiles();

			app.UseAuthentication();

			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "d4n0n's spec"));

			app.UseMvc(routes =>
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action=Index}/{id?}"));
			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
					spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
			});
		}
	}
}