using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.DataAccess.Abstract;
using Shop.DataAccess.Concrete.EntityFramework;
using Shop.WebUI.IdentityCore;

namespace Shop.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFDatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("Shop.WebUI")));
            services.AddDbContext<ApplicationIdentityDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"), b => b.MigrationsAssembly("Shop.WebUI")));
            services.AddIdentity<ApplicationUser,IdentityRole>(options=>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationIdentityDBContext>().AddDefaultTokenProviders();
            services.AddTransient<ICategoryRepository, EFCategoryRepository>();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseAuthentication();
            
            app.UseMvc(route =>
            {
                route.MapRoute(
                      name: "Profile",
                      template: "/Profile/{action}",
                      defaults: new { controller = "Profile", action = "Index" });
                route.MapRoute(
                     name: "Product",
                     template: "{productname}-p-{stockcode}",
                     defaults: new { controller = "Product", action = "Index" });
                route.MapRoute(
                       name: "category",
                       template: "{category}-c-{id}",
                       defaults:new {controller="Category",action="Index"});
               //TODO: Sub Category İçin Gerekli işlemleri ayraç ile yap cart eklemede sıkıntı cıkarıyor
                route.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            SeedData.EnsurePopulated(app);
            SeedIdentity.CreateIdentityUsers(app.ApplicationServices, Configuration).Wait();
        }
    }
}
