using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace NumberCount2
{
    public class NumberCount
    {
        public NumberCount(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.Map("/FutureAction", HandleNumberCount);  // defined in NumberCount.cs (below)

            app.UseMvc(routes =>
            {
                // The method routes.MapRoute() takes three arguments: name, template, and defaults.
                routes.MapRoute(
                    "default",
                    "Index",
                    defaults: new { controller = "NumberCount", action = "Index" });
                routes.MapRoute(
                    "About",  // defined in HomeController.cs
                    "{controller=Home}/{action=Om}/{id?}");
                routes.MapRoute(
                    "Index",
                    "Numbercount/Index",
                    defaults: new { controller = "NumberCount", action = "Index" });
                routes.MapRoute(
                    "Kontakt",
                    "Home/Contact",  // defined in HomeController.cs
                    defaults: new { controller = "Home", action = "Contact" });
                routes.MapRoute(
                    name: "DefaultAction",  // defined in NumberCountController.cs
                    template: "{controller=NumberCount}/{action=DefaultAction}");
            });

            // Add static files to the request pipeline. Without this, the app won't find its CSS files.
            app.UseStaticFiles();
        }

        private static void HandleNumberCount(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("This is the action method you get if you add \"FutureAction\" to the URL.\nTry also \"Home/Contact\"!");
            });
        }
    }
}
