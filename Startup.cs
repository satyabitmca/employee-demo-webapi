using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EmployeeDemo.EmployeeData;
using EmployeeDemo.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeDemo.ErrorHandling;
using EmployeeDemo.Logger;
using NLog;
using System.IO;

namespace EmployeeDemo
{
    public class Startup
    {
       // readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
                       
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      builder =>
            //                      {
            //                          builder.AllowAnyOrigin();
                                                          
            //                      });
            //});
                        
          
            services.AddControllers();
            var ConnString = Configuration.GetConnectionString("EmployeeContextConnctionString");
            services.AddDbContextPool<mySampleDatabaseContext>( options => options.UseSqlServer(ConnString));
            services.AddLogging(config => config.AddConfiguration(Configuration.GetSection("NLog")));
            services.AddScoped<IEmployeeData, SqlEmployeeData>();
            services.AddScoped<IDepartmentData, SqlDepartmentData>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler(logger);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
