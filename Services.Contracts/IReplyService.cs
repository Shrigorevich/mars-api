using Dto;

namespace Services.Contracts;

public interface IReplyService
{
    /// <summary>
    /// Gets the list of replies for specified ticked
    /// </summary>
    /// <param name="ticketId">Ticket identifier</param>
    /// <returns>List of replies</returns>
    Task<IMethodResponse<List<TicketReplyDto>>> GetRepliesAsync(long? ticketId);
    
    /// <summary>
    /// Gets the reply by specified ID
    /// </summary>
    /// <param name="id">Reply identifier</param>
    /// <returns>Reply</returns>
    Task<IMethodResponse<TicketReplyDto>> GetReplyAsync(int id);

    /// <summary>
    /// Create new ticket
    /// </summary>
    /// <remarks>Returns ID of the created reply</remarks>
    /// <param name="ticketId">Ticket identifier</param>
    /// <param name="reply">reply info</param>
    /// <returns>ID</returns>
    Task<IMethodResponse<int>> CreateReplyAsync(long ticketId, CreateTicketReplyDto reply);
    
    /// <summary>
    /// Updates specified reply
    /// </summary>
    /// <param name="id">Reply identifier</param>
    /// <param name="reply">Updated reply info</param>
    /// <returns></returns>
    Task<IMethodResponse> UpdateReplyAsync(int id, UpdateTicketReplyDto reply);
}