using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Demo.BusinessLayer.DbContexts;
using Microsoft.EntityFrameworkCore;
using src.Interfaces;
using Demo.BusinessLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Demo.WebService.Seriveces.Entities.Authentications;
using Demo.WebService.Core.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Google.Cloud.Diagnostics.AspNetCore;

namespace Demo.WebService
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
            services.AddMvc();
            services.AddDbContext<DemoDbContext>(options =>
            {
                // options.UseSqlServer(Configuration.GetConnectionString("NothorwindDatabase"));
                options.UseSqlServer(@"Server=23.100.95.55, 1433;Initial Catalog=NORTHWND;user id=sa;password=s0937s;Persist Security Info=true;");

            });
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICustomersService, CustomersService>();
            // Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "yourdomain.com",
                    ValidAudience = "yourdomain.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("TrainedStaffOnly",
                    policy => policy
                    .RequireClaim("CompletedBasicTraining")
                    .AddRequirements(new MinimumMonthsEmployedRequirement(3)));
            });

            // var projectId = Configuration["Stackdriver:ProjectId"];
            // var serviceName = Configuration["Stackdriver:ServiceName"];
            // var version = Configuration["Stackdriver:Version"];

            // var credential_path = Configuration["Stackdriver:CredentialPath"];
            // System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);

            services.AddGoogleExceptionLogging(options =>
            {
                options.ProjectId = "dotnetcoredemo-208409"; //projectId;
                options.ServiceName = "dotnetcoredemo-208409.appspot.com";// serviceName;
                options.Version = "1.0";// version;
            });

            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // loggerFactory.AddLog4Net();

            app.UseAuthentication();

            #region GoogleLogging

            // Configure logging service.
            loggerFactory.AddGoogle("dotnetcoredemo-208409");
            // // Write the log entry.
            // var logger = loggerFactory.CreateLogger("testStackdriverLogging");
            // logger.LogInformation("Stackdriver sample started. This is a log message.");
            // Use before handling any requests to ensure all unhandled exceptions are reported.
            app.UseGoogleExceptionLogging();
            #endregion

            #region Swagger

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            #endregion

            app.UseMvc();
        }
    }
}
