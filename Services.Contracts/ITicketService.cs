using Dto;

namespace Services.Contracts;

public interface ITicketService
{
    /// <summary>
    /// Gets the whole list of tickets
    /// </summary>
    /// <returns>List of tickets</returns>
    Task<IMethodResponse<List<TicketDto>>> GetTicketsAsync();
    
    /// <summary>
    /// Gets the ticket provided ID
    /// </summary>
    /// <param name="id">Ticket identifier</param>
    /// <returns>Ticket</returns>
    Task<IMethodResponse<TicketDto>> GetTicketAsync(long id);
    
    /// <summary>
    /// Create new ticket
    /// </summary>
    /// <remarks>Returns ID of the created ticket</remarks>
    /// <param name="ticket">Ticket info</param>
    /// <returns>ID</returns>
    Task<IMethodResponse<long>> CreateTicketAsync(CreateTicketDto ticket);
    
    /// <summary>
    /// Updates specified ticket
    /// </summary>
    /// <param name="id">Ticket identifier</param>
    /// <param name="ticket">Updated ticket info</param>
    /// <returns></returns>
    Task<IMethodResponse> UpdateTicketAsync(int id, UpdateTicketDto ticket);
}