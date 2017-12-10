using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HW2.Services;
using Microsoft.EntityFrameworkCore;

namespace HW2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=StudentsDB;
            Integrated Security=True;
            Connect Timeout=30;
            Encrypt=False;
            TrustServerCertificate=True;
            ApplicationIntent=ReadWrite;
            MultiSubnetFailover=False";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StudentDbContext>(x => x.UseSqlServer(ConnectionString));

            services.AddTransient<IStudentService, StudentService>(StudentServiceFactory);             
            services.AddTransient<ITestService, TestService>(TestServiceFactory);

            services.AddMvc();
        }
        private StudentService StudentServiceFactory(IServiceProvider serviceProvider)
        {
            return new StudentService(serviceProvider.GetService<StudentDbContext>());
        }

        private TestService TestServiceFactory(IServiceProvider serviceProvider)
        {
            return new TestService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
