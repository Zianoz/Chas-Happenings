using Azure;
using Domain.Models;
using Domain.Models.ConectionTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domain.Enums;

namespace Infrastructure.Data
{
    public class ChasHappeningsDbContext : DbContext
    {
        public ChasHappeningsDbContext(DbContextOptions<ChasHappeningsDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserEvent> UserInteractions { get; set; }

        // Sedding table below
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var UserModel = modelBuilder.Entity<User>();
            var EventModel = modelBuilder.Entity<Event>();
            var ArticleModel = modelBuilder.Entity<Article>();
            var TagModel = modelBuilder.Entity<Tag>();
            var CommentModel = modelBuilder.Entity<Comment>();
            var NotificationModel = modelBuilder.Entity<Notification>();
            var UserEventModel = modelBuilder.Entity<UserEvent>();

            // Seed admin user with hardcoded password hash for "123"
            // This hash is static to avoid EF Core pending model changes warning
            UserModel.HasData(new User
            {
                Id = 1,
                Username = "admin",
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@chashappenings.com",
                Phone = null,
                Course = null,
                Role = UserRoles.Admin,
                ProfilePictureUrl = null,
                UserDescription = "System Administrator",
                PasswordHash = "AQAAAAIAAYagAAAAEOF5qkGEC7KpKy9xlZYKZYWgOQUQlKqMDKh/ludIwt3VY2haVwXqL0HU9C1IiO9eAg=="
            });
        }
    }
}
