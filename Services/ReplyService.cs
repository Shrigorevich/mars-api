using AutoMapper;
using CommonObjects;
using DataAccess.Contracts;
using Dto;
using Entities;
using Services.Contracts;

namespace Services;

public class ReplyService(IReplyRepository repository, IMapper mapper) : IReplyService
{
    public async Task<IMethodResponse<List<TicketReplyDto>>> GetRepliesAsync(long? ticketId)
    {
        var entities = await repository.GetAllAsync(ticketId);
        var replies = mapper.Map<List<TicketReplyDto>>(entities);
        return MethodResponse<List<TicketReplyDto>>.Success(replies);
    }

    public async Task<IMethodResponse<TicketReplyDto>> GetReplyAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null)
            return MethodResponse<TicketReplyDto>.NotFound($"Reply with id {id} not found");
        
        var reply = mapper.Map<TicketReplyDto>(entity);
        return MethodResponse<TicketReplyDto>.Success(reply);
    }

    public async Task<IMethodResponse<int>> CreateReplyAsync(long ticketId, CreateTicketReplyDto reply)
    {
        var entity = mapper.Map<TicketReply>(reply);
        entity.TicketId = ticketId;
        var id = await repository.AddAsync(entity);
        return MethodResponse<int>.Created(id);
    }

    public async Task<IMethodResponse> UpdateReplyAsync(int id, UpdateTicketReplyDto reply)
    {
        var existingReply = await repository.GetByIdAsync(id);
        if (existingReply == null)
            return MethodResponse.Failure(ApiErrorCode.ResourceNotFound, $"Reply with id {id} not found");

        mapper.Map(reply, existingReply);
        await repository.UpdateAsync(existingReply);
        return MethodResponse.NoContent();
    }
}