namespace Timelogger.Api
{
	using Commands;
	using Queries;
    using Microsoft.OpenApi.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Hosting;
    using Timelogger.Entities;
	using Timelogger.Repositories;
	using System;

	public class Startup
	{
		private readonly IWebHostEnvironment _environment;
		public IConfigurationRoot Configuration { get; }

		public Startup(IWebHostEnvironment env)
		{
			_environment = env;

			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// CQRS + Repositories
			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<ITimeEntryRepository, TimeEntryRepository>();
			services.AddScoped<IProjectCommand, ProjectCommand>();
			services.AddScoped<IProjectQuery, ProjectQuery>();
			services.AddScoped<ITimeEntryCommand, TimeEntryCommand>();
			services.AddScoped<ITimeEntryQuery, TimeEntryQuery>();

			// Add framework services.
			services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("e-conomic interview"));
			services.AddLogging(builder =>
			{
				builder.AddConsole();
				builder.AddDebug();
			});

			services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "e-conomic TimeLogger API",
                    Description = "Welcome to the e-conomic TimeLogger API documentation",
                });
            });

			if (_environment.IsDevelopment())
			{
				services.AddCors();
			}
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseCors(builder => builder
					.AllowAnyMethod()
					.AllowAnyHeader()
					.SetIsOriginAllowed(origin => true)
					.AllowCredentials());
			}

			app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "e-conomic TimeLogger API V1");
            });

			var serviceScopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
			using (var scope = serviceScopeFactory.CreateScope())
			{
				SeedDatabase(scope);
			}
		}

		private static void SeedDatabase(IServiceScope scope)
		{
			var context = scope.ServiceProvider.GetService<ApiContext>();
			var testProject1 = new Project(
				id: 1,
				name: "e-conomic Interview Proj1",
				endDate: Convert.ToDateTime("2022-12-01"),
				price: 550000,
				customerNumber: 101,
				notes: "Default project",
				isFinished: true,
				contributorNumber: 1001,
				status: 0);

			var testProject2 = new Project(
				id: 2,
				name: "e-conomic Interview Proj2",
				endDate: Convert.ToDateTime("2023-03-01"),
				price: 325000,
				customerNumber: 101,
				notes: "Default project",
				isFinished: true,
				contributorNumber: 1001,
				status: 0);

			var testTimeEntry1 = new TimeEntry(
				id: 1,
				contributorNumber: 1001,
				insertedAt: DateTime.UtcNow,
				entryDate: Convert.ToDateTime("2022-09-12"),
				projectNumber: 1,
				hours: 8,
				notes: "Work for e-conomic project");

			var testTimeEntry2 = new TimeEntry(
				id: 2,
				contributorNumber: 1001,
				insertedAt: DateTime.UtcNow,
				entryDate: Convert.ToDateTime("2022-09-13"),
				projectNumber: 1,
				hours: 2,
				notes: "Work for e-conomic project");

			var testTimeEntry3 = new TimeEntry(
				id: 3,
				contributorNumber: 1001,
				insertedAt: DateTime.UtcNow,
				entryDate: Convert.ToDateTime("2022-09-14"),
				projectNumber: 2,
				hours: 24,
				notes: "Work for e-conomic project");

			context.Projects.Add(testProject1);
			context.Projects.Add(testProject2);
			context.TimeEntries.Add(testTimeEntry1);
			context.TimeEntries.Add(testTimeEntry2);
			context.TimeEntries.Add(testTimeEntry3);
			context.SaveChanges();
		}
	}
}