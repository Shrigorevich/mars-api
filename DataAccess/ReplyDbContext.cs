using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ReplyDbContext(DbContextOptions<ReplyDbContext> options) : DbContext(options)
{
    public DbSet<TicketReply> Replies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TicketReply>(entity =>
        {
            entity.ToTable("TicketReply", "Support");

            entity.Property(e => e.PublishedAt)
                .HasColumnName("ReplyDate");
            
            entity.Property(e => e.TicketId)
                .HasColumnName("TId");
            
            entity.Property(e => e.Content)
                .HasColumnName("Reply");
            
            entity.Property(t => t.Id)
                .HasColumnName("ReplyId")
                .UseIdentityColumn();
        });

        base.OnModelCreating(modelBuilder);
    }
}