using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmpManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            ////To Serve Defualt Documents
            //DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("Foo.html");

            ////To change or use Default Document
            //app.UseDefaultFiles(options);

            ////To Serve Static Files
            //app.UseStaticFiles();            

            //ALTERNATE way of serving #30 to #39
            FileServerOptions options = new FileServerOptions();
            options.DefaultFilesOptions.DefaultFileNames.Clear();
            options.DefaultFilesOptions.DefaultFileNames.Add("Foo.html");
            app.UseFileServer(options);


            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW1: Incoming Request");
            //    await context.Response.WriteAsync("Hello Venkat From Python");
            //    logger.LogInformation("MW1: Outgoing Response");
            //    await next();
            //});
            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW2: Incoming Request");
            //    await context.Response.WriteAsync("Hello Venkat From Python");
            //    logger.LogInformation("MW2: Outgoing Response");
            //    await next();
            //});
            app.Run(async (context) =>
            {
                throw new Exception("Test Exception Raised");
                await context.Response.WriteAsync("Hello Venkat for testing .Net Core");
                logger.LogInformation("MW3: Request Handled and Response Produced");
            });
        }
    }
}
