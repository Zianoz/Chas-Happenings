using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.ConectionTables;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed User
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "MaxL",
                FirstName = "Maximillian",
                LastName = "Lundberg",
                Email = "max@example.com",
                Phone = "+46700000000",
                PasswordHash = "hashedpassword123", // placeholder
                Course = "Fullstack .NET",
                Role = "Admin",
                ProfilePictureUrl = "https://example.com/profile.jpg",
                UserDescription = "Admin user seeded for testing."
            });

            // Seed Event
            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = 1,
                EventTitle = "Launch Party",
                EventDescription = "First event for testing",
                EventNote = "Bring snacks",
                EventNote2 = "Don’t forget name tags",
                EventDate = DateTime.UtcNow.AddDays(7),
                StartTime = new TimeSpan(18, 0, 0),
                EndTime = new TimeSpan(21, 0, 0),
                Duration = new TimeSpan(3, 0, 0),
                Location = "Chas Academy"
            });
            // Seed UserEvent (connection)
            modelBuilder.Entity<UserEvent>().HasData(new UserEvent
            {
                Id = 1,
                UserId = 1,
                EventId = 1,
                Interaction = "Interested"
            });

        }
    }
}
