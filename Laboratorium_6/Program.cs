using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace Laboratorium_6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<Data.AppDbContext>();
            builder.Services.AddDefaultIdentity<IdentityUser>()    
            .AddRoles<IdentityRole>()                             
             .AddEntityFrameworkStores<Data.AppDbContext>();     
            builder.Services.AddTransient<IProductService, EFProductService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();                                 // dodaæ
            app.UseAuthorization();                                  // dodaæ
            app.UseSession();                                        // dodaæ
            app.MapRazorPages();                                     // dodaæ
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}