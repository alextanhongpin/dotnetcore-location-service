using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Company.LocationService.Models;
using Company.LocationService.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Company.LocationService
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
            var transient = true;
            if (Configuration.GetSection("transient") != null)
            {
                transient = Boolean.Parse(Configuration.GetSection("transient").Value);
            }

            if (transient)
            {
                Console.WriteLine("Using transient location record repository");
                services.AddSingleton<ILocationRecordRepository, InMemoryLocationRecordRepository>();
            } else {
                var connectionString = Configuration.GetSection("postgres:cstr").Value;
                services.AddEntityFrameworkNpgsql().
                    AddDbContext<LocationDbContext>(options => options.UseNpgsql(connectionString));
                Console.WriteLine($"Using {connectionString} for DB connection string");
            }
            services.AddScoped<ILocationRecordRepository, LocationRecordRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
