using Microsoft.EntityFrameworkCore;

namespace TicketToDo.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; } 
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "todo", Name = "To Do" },
                new Status { StatusId = "inprogress", Name = "In Progress" },
                new Status { StatusId = "qa", Name = "Quality Assurance" },
                new Status { StatusId = "done", Name = "Done" }
                );

           modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 5, Name = "task", Description = "do this task", DueDate = new DateTime(2023, 12, 21), SprintNumber = 4, PointValue = 2, StatusId = "qa" }
                );
        }
    }
}
