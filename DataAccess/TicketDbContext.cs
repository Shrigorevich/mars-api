using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class TicketDbContext(DbContextOptions<TicketDbContext> options) : DbContext(options)
{
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("Ticket", "Support");

            entity.Property(e => e.CreatedAt)
                .HasColumnName("Date");
            
            entity.Property(e => e.UpdatedAt)
                .HasColumnName("LastModified");
            
            entity.Property(t => t.Id)
                .UseIdentityColumn();
        });

        base.OnModelCreating(modelBuilder);
    }
}