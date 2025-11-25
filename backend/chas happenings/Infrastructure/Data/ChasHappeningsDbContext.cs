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
            var userModel = modelBuilder.Entity<User>();
            var eventModel = modelBuilder.Entity<Event>();
            var articleModel = modelBuilder.Entity<Article>();
            var tagModel = modelBuilder.Entity<Tag>();
            var commentModel = modelBuilder.Entity<Comment>();
            var notificationModel = modelBuilder.Entity<Notification>();
            var userEventModel = modelBuilder.Entity<UserEvent>();

            userModel.HasData(new User
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

            userModel.HasData(new User
            {
                Id = 2,
                Username = "max",
                FirstName = "Maximillian",
                LastName = "Lundberg",
                Email = "max@example.com",
                Phone = null,
                PasswordHash = "demo-hash",
                Course = "Fullstack .NET",
                Role = UserRoles.Student,
                ProfilePictureUrl = null,
                UserDescription = "Test seeded user"
            });

            eventModel.HasData(new Event
            {
                Id = 1,
                Title = "Chas Intro Day",
                Description = "Introduction event for Chas Happenings.",
                Presentation = null,
                Text1 = null,
                Text2 = null,
                EventCreated = new DateTime(2024, 11, 1, 9, 0, 0, DateTimeKind.Utc),
                EventDate = new DateTime(2024, 11, 15),
                StartTime = new TimeSpan(10, 0, 0),
                EndTime = new TimeSpan(12, 0, 0),
                Location = "Chas Academy, Stockholm",
                Type = EventType.StudentBodey   
            });
            eventModel.HasData(new Event
            {
                Id = 10,
                Title = "party",
                Description = "hallowen",
                Presentation = null,
                Text1 = null,
                Text2 = null,
                EventCreated = new DateTime(2024, 11, 1, 9, 0, 0, DateTimeKind.Utc),
                EventDate = new DateTime(2025, 7, 15),
                StartTime = new TimeSpan(10, 0, 0),
                EndTime = new TimeSpan(12, 0, 0),
                Location = "Chas Academy, Stockholm",
                Type = EventType.StudentBodey
            });


            tagModel.HasData(new Tag
            {
                Id = 1,
                TagName = "Workshop",
                FK_event = 1 
            });

            commentModel.HasData(new Comment
            {
                Id = 1,
                AuthorId = 1,
                EventId = 1,
                Text = "Looking forward to this event!",
                ProfilePicture = "/images/default-profile.png",
                CreatedAt = new DateTime(2024, 11, 2, 8, 30, 0, DateTimeKind.Utc)
            });


        }
    }
}
