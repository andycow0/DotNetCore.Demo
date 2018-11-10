using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.WebSite {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
            }

            //Redirect non api calls to angular app that will handle routing of the app.    
            app.Use (async (context, next) => {
                await next ();
                if (context.Response.StatusCode == 404 &&
                    !Path.HasExtension (context.Request.Path.Value) &&
                    !context.Request.Path.Value.StartsWith ("/api/")) {
                    context.Request.Path = "/index.html";
                    context.Response.StatusCode = 200;

                    await next ();
                }
            });

            // configure the app to serve index.html from /wwwroot folder    
            app.UseDefaultFiles ();
            app.UseStaticFiles ();
            // configure the app for usage as api    
            app.UseMvcWithDefaultRoute ();

            // app.UseMvc (routes => {
            //     routes.MapRoute (
            //         name: "default",
            //         template: "{controller=Home}/{action=Index}/{id?}");

            //     // routes.MapSpaFallbackRoute ("spa-fallback", new { controller = "Home", action = "Angular" });
            // });

        }
    }
}