using Enitiy_framework_with_Swagger_API.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enitiy_framework_with_Swagger_API
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
            //services.AddRazorPages();


            // BELOW CODDED ADDED

            services.AddMvc();


            services.AddDbContext<CRUDContext>(options => options.UseSqlServer(Configuration.GetConnectionString("dbUniversity")));


            services.AddSwaggerGen(
                c => c.SwaggerDoc
                    (
                    "V1", new OpenApiInfo
                    {
                        Title = "My test API",
                        Version = "V1"
                    }
                    )
                );

            // ABOVE CODE ADDED


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            //BELOW CODE ADDED

            app.UseSwagger();

            app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    }
             );



            //ABOVE CODE ADDED

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
