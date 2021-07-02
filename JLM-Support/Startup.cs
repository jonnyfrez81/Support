using JLM_Support.Models.IcaProcab;
using JLM_Support.Models.Klarna;
using JLM_Support.Models.PwcIca;
using JLM_Support.Models.SieSync;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JLM_Support
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Serilog.Log.Logger = new LoggerConfiguration()
       .ReadFrom.Configuration(configuration)
       .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<KlarnaV3Context>(options => options.UseSqlServer(Configuration.GetConnectionString("KlarnaV3")));
            services.AddDbContext<SieSyncContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SieSync")));
            services.AddDbContext<pwc_icaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PwcIca")));
            services.AddDbContext<IcaProcabContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IcaProcab")));
            

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseRequestLocalization("en-UY", "fr-FR");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
