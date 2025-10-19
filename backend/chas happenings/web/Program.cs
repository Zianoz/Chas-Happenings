using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
//using Infrastructure.Repositories.IRepositories;
using Infrastructure.Repositories;
using Application.Services;
using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
//using Application.Services.IServices;

namespace chas_happenings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ChasHappeningsDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IEventRepositories, EventRepositories>();
            builder.Services.AddScoped<IEventServices, EventServises>();

            builder.Services.AddScoped<ITagRepositories, TagRepositories>();
            builder.Services.AddScoped<ITagServices, TagServices>();

            //Add swagger for API testing
            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Chas Happenings API",
                    Version = "v1"
                });
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
