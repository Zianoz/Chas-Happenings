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

            eventModel.HasData(
    new Event
    {
        Id = 11,
        Title = "Intro to .NET Day",
        Description = "Overview of C# and .NET for new students.",
        Presentation = "Slides about CLR, runtime and basic syntax.",
        Text1 = "Bring your laptop and have Visual Studio installed.",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 1, 9, 0, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 2),
        StartTime = new TimeSpan(9, 0, 0),
        EndTime = new TimeSpan(11, 0, 0),
        Location = "Chas Academy, Classroom A",
        Type = EventType.School
    },
    new Event
    {
        Id = 12,
        Title = "Architecture Workshop",
        Description = "Hands-on session about MVC and layered architecture.",
        Presentation = "Whiteboard session with sample diagrams.",
        Text1 = "Split into groups and design a small system.",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 2, 10, 0, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 5),
        StartTime = new TimeSpan(13, 0, 0),
        EndTime = new TimeSpan(16, 0, 0),
        Location = "Chas Academy, Lab 1",
        Type = EventType.School
    },
    new Event
    {
        Id = 13,
        Title = "Exam Prep Seminar",
        Description = "Review of key topics before the winter exam.",
        Presentation = "Q&A session with live coding.",
        Text1 = "Students can bring their own questions and code.",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 3, 8, 30, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 9),
        StartTime = new TimeSpan(10, 0, 0),
        EndTime = new TimeSpan(12, 30, 0),
        Location = "Chas Academy, Auditorium",
        Type = EventType.School
    },
    new Event
    {
        Id = 14,
        Title = "Student Council Meeting",
        Description = "Monthly meeting for the student body board.",
        Presentation = null,
        Text1 = "Agenda: feedback on courses, upcoming events.",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 4, 9, 15, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 3),
        StartTime = new TimeSpan(15, 0, 0),
        EndTime = new TimeSpan(17, 0, 0),
        Location = "Chas Academy, Meeting Room 2",
        Type = EventType.StudentBodey
    },
    new Event
    {
        Id = 15,
        Title = "Winter Feedback Forum",
        Description = "Open forum where students discuss improvements.",
        Presentation = "Short intro by student representatives.",
        Text1 = "Snacks and drinks provided.",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 5, 11, 0, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 10),
        StartTime = new TimeSpan(14, 0, 0),
        EndTime = new TimeSpan(16, 0, 0),
        Location = "Chas Academy, Lounge",
        Type = EventType.StudentBodey
    },
    new Event
    {
        Id = 16,
        Title = "Student Body Planning Night",
        Description = "Planning upcoming events for the spring semester.",
        Presentation = null,
        Text1 = "Focus on social and networking events.",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 6, 12, 0, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 17),
        StartTime = new TimeSpan(17, 30, 0),
        EndTime = new TimeSpan(19, 30, 0),
        Location = "Chas Academy, Meeting Room 1",
        Type = EventType.StudentBodey
    },
    new Event
    {
        Id = 17,
        Title = "Backend Deep Dive",
        Description = "Lesson focusing on EF Core and database design.",
        Presentation = "Code examples and live migrations.",
        Text1 = "We will look at relationships and seeding.",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 7, 9, 45, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 4),
        StartTime = new TimeSpan(9, 0, 0),
        EndTime = new TimeSpan(12, 0, 0),
        Location = "Chas Academy, Lab 2",
        Type = EventType.Leasson
    },
    new Event
    {
        Id = 18,
        Title = "Frontend Practice Session",
        Description = "Lesson focusing on React, components and props.",
        Presentation = "Short demo followed by coding exercises.",
        Text1 = "Students build a small page in groups.",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 8, 10, 0, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 11),
        StartTime = new TimeSpan(13, 0, 0),
        EndTime = new TimeSpan(16, 0, 0),
        Location = "Chas Academy, Classroom B",
        Type = EventType.Leasson
    },
    new Event
    {
        Id = 19,
        Title = "Testing and Quality Lesson",
        Description = "Intro to unit testing and code quality tools.",
        Presentation = "Examples with xUnit and basic test structure.",
        Text1 = "We look at how to write simple tests for services.",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 9, 11, 30, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 18),
        StartTime = new TimeSpan(10, 0, 0),
        EndTime = new TimeSpan(12, 30, 0),
        Location = "Chas Academy, Lab 3",
        Type = EventType.Leasson
    },
    new Event
    {
        Id = 20,
        Title = "Winter Game Night",
        Description = "Board games and snacks hosted by students.",
        Presentation = null,
        Text1 = "Bring your favorite board game if you have one.",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 10, 18, 0, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 6),
        StartTime = new TimeSpan(18, 0, 0),
        EndTime = new TimeSpan(22, 0, 0),
        Location = "Chas Academy, Common Area",
        Type = EventType.StudentEvent
    },
    new Event
    {
        Id = 21,
        Title = "Holiday Coding Jam",
        Description = "Casual coding evening with music and fika.",
        Presentation = null,
        Text1 = "Work on your own project or join a group.",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 11, 17, 0, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 13),
        StartTime = new TimeSpan(17, 30, 0),
        EndTime = new TimeSpan(21, 0, 0),
        Location = "Chas Academy, Open Space",
        Type = EventType.StudentEvent
    },
    new Event
    {
        Id = 22,
        Title = "End of Year Social",
        Description = "Casual gathering before the winter break.",
        Presentation = null,
        Text1 = "Short thank-you speech and informal mingle.",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 12, 16, 0, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 20),
        StartTime = new TimeSpan(16, 0, 0),
        EndTime = new TimeSpan(19, 0, 0),
        Location = "Chas Academy, Lounge",
        Type = EventType.StudentEvent
    },
    new Event
    {
        Id = 23,
        Title = "Presentation",
        Description = "Chas Academy group presentation",
        Presentation = null,
        Text1 = "Se you there ^^",
        Text2 = null,
        EventCreated = new DateTime(2024, 11, 12, 16, 0, 0, DateTimeKind.Utc),
        EventDate = new DateTime(2025, 11, 26),
        StartTime = new TimeSpan(9, 0, 0),
        EndTime = new TimeSpan(16, 0, 0),
        Location = "Rum 8, våning 9",
        Type = EventType.Leasson
    }
);



        }
    }
}
