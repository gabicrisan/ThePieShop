using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebShop.Models;

namespace WebShop
{
    public class Startup
    {
        // Iconfiguration aduce datele de db din appsettings
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //setam dbcontext-ul 
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // inregistram in services clasele pt dependency injection 
            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            //invocam getcart de la primul request pt a introduce cartId-ul
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.AddScoped<IOrderRepository, OrderRepository>();
            //suport pt accesare sesiuni
            services.AddHttpContextAccessor();
            //support pt sesiuni
            services.AddSession();
            // implementam mvc
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // redirect http la https
            app.UseHttpsRedirection();
            // middleware pt a putea folosi fisiere statice (wwwroot)
            app.UseStaticFiles();
            //middleware pt suport sesiuni (obligatoriu inainte de routing!!!)
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // mapam orice request cu actiunea unui controller + id optional
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
