using Entities;

namespace DataAccess.Contracts;

public interface IReplyRepository
{
    Task<List<TicketReply>> GetAllAsync(long? ticketId);
    Task<TicketReply?> GetByIdAsync(int id);
    Task<int> AddAsync(TicketReply ticket);
    Task UpdateAsync(TicketReply ticket);
}