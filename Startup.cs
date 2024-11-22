using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiReport.Context;
using WebApiReport.ModelCibaliungDanMalingping;
using WebApiReport.ModelPanembong;
using WebApiReport.Models;

namespace WebApiReport
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
            services.AddDbContext<mixradius_radDBContext>(options =>
        options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(10, 4, 17))));


            services.AddDbContext<PenembongDBContext>(options =>
        options.UseMySql(Configuration.GetConnectionString("DefaultConnection2"),
            new MySqlServerVersion(new Version(10, 4, 17)))); 

            services.AddDbContext<CibaliungDBContext>(options =>
       options.UseMySql(Configuration.GetConnectionString("DefaultConnection3"),
           new MySqlServerVersion(new Version(10, 4, 17)))); 

       //     services.AddDbContext<CibaliungDBContext>(options =>
       //options.UseMySql(Configuration.GetConnectionString("DefaultConnection4"),
       //    new MySqlServerVersion(new Version(10, 4, 17)))); // Use the version of your MariaDB server

            services.AddDbContext<DbContextLinked>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));// sql server


                                

            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API WSVAP (WebSmartView)", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
            app.UseDeveloperExceptionPage();
               
           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable Swagger
            app.UseSwagger();

            // Enable Swagger UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/WebApiReport/swagger/v1/swagger.json", "My API V1");
              //  c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
    }
}
