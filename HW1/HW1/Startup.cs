using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace HW1
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                var indicator1 = new Indicator();
                indicator1.Start();
                await context.Response.WriteAsync("<br>Start indicator!");
                await next();
                indicator1.End();
                await context.Response.WriteAsync($"<br>Indicator1 = {indicator1.Time()} ms");
            });

            app.UseMiddleware<Middleware>();

            app.Use(async (context, next) =>
            {
                var indicator2 = new Indicator();
                indicator2.Start();
                await context.Response.WriteAsync("<br>Start second indicator2!");
                //await next();
                indicator2.End();
                await context.Response.WriteAsync($"<br>Indicator2 = {indicator2.Time()} ms");
            });
        }
    }
}
