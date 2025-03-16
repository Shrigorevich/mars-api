using AutoMapper;
using CommonObjects;
using DataAccess.Contracts;
using Dto;
using Entities;
using Services.Contracts;

namespace Services;

public class TicketService(ITicketRepository repository, IMapper mapper) : ITicketService
{
    public async Task<IMethodResponse<List<TicketDto>>> GetTicketsAsync()
    {
        var tickets = await repository.GetAllAsync();
        var mappedTickets = mapper.Map<List<TicketDto>>(tickets);
        return MethodResponse<List<TicketDto>>.Success(mappedTickets);
    }

    public async Task<IMethodResponse<TicketDto>> GetTicketAsync(long id)
    {
        var ticket = await repository.GetByIdAsync(id);

        if (ticket == null)
            return MethodResponse<TicketDto>.NotFound($"Ticket with id {id} not found");
        
        var mappedTicket = mapper.Map<TicketDto>(ticket);
        return MethodResponse<TicketDto>.Success(mappedTicket);
    }

    public async Task<IMethodResponse<long>> CreateTicketAsync(CreateTicketDto ticket)
    {
        var ticketEntity = mapper.Map<Ticket>(ticket);
        var id = await repository.AddAsync(ticketEntity);
        return MethodResponse<long>.Created(id);
    }

    public async Task<IMethodResponse> UpdateTicketAsync(int id, UpdateTicketDto ticket)
    {
        var existingTicket = await repository.GetByIdAsync(id);
        if (existingTicket == null)
            return MethodResponse.Failure(ApiErrorCode.ResourceNotFound, $"Ticket with id {id} not found");

        mapper.Map(ticket, existingTicket);
        await repository.UpdateAsync(existingTicket);
        return MethodResponse.NoContent();
    }
}