using DataAccess.Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ReplyRepository(ReplyDbContext context) : IReplyRepository
{
    public async Task<List<TicketReply>> GetAllAsync(long? ticketId)
    {
        var query = context.Replies.AsQueryable();

        if (ticketId.HasValue)
            query = query.Where(r => r.TicketId == ticketId);
        
        return await query.ToListAsync();
    }

    public async Task<TicketReply?> GetByIdAsync(int id)
    {
        return await context.Replies.FindAsync(id);
    }

    public async Task<int> AddAsync(TicketReply reply)
    {
        var entity = await context.Replies.AddAsync(reply);
        await context.SaveChangesAsync();
        return entity.Entity.Id;
    }

    public async Task UpdateAsync(TicketReply reply)
    {
        context.Replies.Attach(reply);
        await context.SaveChangesAsync();
    }
}