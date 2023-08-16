using Microsoft.AspNetCore.HttpOverrides;

namespace PersonalWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor
            });

            app.UseStatusCodePagesWithReExecute("/Status/Http{0}");

            app.UseStaticFiles();

            app.UseRouting();

            /* app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); */

            app.MapControllerRoute(
                name: "root",
                pattern: "{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" }
            );

            app.Run();
        }
    }
}