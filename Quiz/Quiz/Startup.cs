using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quiz.DataBase;
using Quiz.DataBase.IProviders;
using Quiz.DataBase.Providers;

namespace Quiz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PostgresContext>(options => options.UseNpgsql(connection));
            services.AddRazorPages().AddRazorPagesOptions(options=> { options.Conventions.AddPageRoute("/", "/CounterTable"); });
            services.AddControllersWithViews();
            services.AddScoped<ICountersProvider, CountersProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PostgresContext context, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                logger.LogWarning("LogWarning ", ex.Message);
            }
        }
    }
}
