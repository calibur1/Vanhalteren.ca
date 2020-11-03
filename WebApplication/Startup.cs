using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace WebApplication
{
    public class Startup
    {
        public readonly IConfiguration Configuration;
        public readonly IWebHostEnvironment WebHostEnvironment;


        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Log out if app is dev or prod
            Console.WriteLine($"WebHostEnvironment: {WebHostEnvironment.EnvironmentName}");
             
            //log out
            Console.WriteLine("GetEnvironmentVariables: ");
            foreach (DictionaryEntry item in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($" {item.Key} = {item.Value}");
            }
            
            //Setup the database context with either the development appsettings or from local environment variables
            services.AddDbContextPool<RazorPagesMovieContext>(
                options => options.UseMySql((WebHostEnvironment.IsDevelopment()
                    ? Configuration.GetConnectionString("DBConnectionString")
                    : Environment.GetEnvironmentVariable("CONNECTIONSTRING_TESTDB"))
                                            ?? throw new NullReferenceException("Services startup, DBContext environment variable not found"))
            );

            services.AddRazorPages();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}