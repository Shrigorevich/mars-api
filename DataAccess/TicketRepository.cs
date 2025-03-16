using DataAccess.Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class TicketRepository(TicketDbContext context) : ITicketRepository
{
    public async Task<List<Ticket>> GetAllAsync()
    {
        return await context.Tickets.ToListAsync();
    }

    public async Task<Ticket?> GetByIdAsync(long id)
    {
        return await context.Tickets.FindAsync(id);
    }

    public async Task<long> AddAsync(Ticket ticket)
    {
        var entity = await context.Tickets.AddAsync(ticket);
        await context.SaveChangesAsync();
        return entity.Entity.Id;
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        context.Tickets.Attach(ticket);
        await context.SaveChangesAsync();
    }
}