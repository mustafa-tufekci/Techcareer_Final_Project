using EventHub.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EventHub.DAL.Concrete
{
    public class EventHubDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<TicketSalesCompany> TicketSalesCompanies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=OnlineEventProject;Trusted_Connection=True;Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    FirstName = "Martin",
                    LastName = "McFly",
                    Email = "admin@admin.com",
                    Password = "Password",
                }
            );
        }

    }
}
