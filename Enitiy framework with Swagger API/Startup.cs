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

            //below lines commeneted
            //services.AddSwaggerGen(
            //    c => c.SwaggerDoc
            //        (
            //        "V1", new OpenApiInfo
            //        {
            //            Title = "My test API",
            //            Version = "V1"
            //        }
            //        )
            //    );


            //below lines added
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });



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


            //below lines commenetd
            //app.UseSwaggerUI(c =>
            //        {
            //            //c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            //            c.SwaggerEndpoint("./v1/swagger.json", "My API V1");
            //            // c.RoutePrefix = string.Empty;
            //        }
            // );
 

            //below lines added

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/swagger/V1/swagger.json";
            });
            app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "API v1"));



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
