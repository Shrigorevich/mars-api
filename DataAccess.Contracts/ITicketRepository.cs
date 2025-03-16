using Entities;

namespace DataAccess.Contracts;

public interface ITicketRepository
{
    Task<List<Ticket>> GetAllAsync();
    Task<Ticket?> GetByIdAsync(long id);
    Task<long> AddAsync(Ticket ticket);
    Task UpdateAsync(Ticket ticket);
}