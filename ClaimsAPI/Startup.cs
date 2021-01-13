using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClaimsAPI.Definitions;
using ClaimsAPI.Implementations;
using ClaimsAPI.Infrastructure;
using ClaimsAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClaimsAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.ConfigureMemberClaimContextAsync(Configuration);
			
			services.AddTransient<IClaimsRepository, ClaimsRepository>();
			services.AddTransient<IClaimsService, ClaimsService>();
			services.AddSwaggerGen();
			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseSwagger();

			app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Claims API"));

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}

	static class CustomExtentions
	{
		public static void ConfigureMemberClaimContextAsync(this IServiceCollection services,IConfiguration configuration)
		{
			var webEnv = services.BuildServiceProvider().GetService<IWebHostEnvironment>();
			var memberClaimsContextSeed = new MemberClaimsContextSeed(configuration.GetSection("SeedData"), webEnv);
			var memberClaimsContext = new MemberClaimsContext() { Members = memberClaimsContextSeed.GetMemberFromFile(), Claims = memberClaimsContextSeed.GetCliamsFromFile() };

			services.AddSingleton(memberClaimsContext);
		}
	}
}

