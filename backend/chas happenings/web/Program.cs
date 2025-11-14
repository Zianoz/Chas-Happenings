using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
using Application.Services;
using Domain.Models;
using Infrastructure.Data;
//using Infrastructure.Repositories.IRepositories;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;  // Add this if needed
using Swashbuckle.AspNetCore.SwaggerUI; // Add this if needed


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
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b =>b.MigrationsAssembly("chas_happenings.Infrastructure"));
            });

            builder.Services.AddScoped<IEventRepositories, EventRepositories>();
            builder.Services.AddScoped<IEventServices, EventServices>();

            builder.Services.AddScoped<ITagRepositories, TagRepositories>();
            builder.Services.AddScoped<ITagServices, TagServices>();

            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<ICommentService, CommentService>();

            builder.Services.AddScoped<IUserRepositories, UserRepositories>();
            builder.Services.AddScoped<IUserService, UserServices>();

            //Register password hasher service
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IAdminService, AdminService>();



            //Add swagger for API testing
            builder.Services.AddControllers();
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chas Happenings API V1");
                c.RoutePrefix = "swagger";
            });

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

            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
