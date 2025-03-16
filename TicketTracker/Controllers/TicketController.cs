using Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace TicketTracker.Controllers;

[ApiController]
[Route("api/v1/tickets")]
public class TicketController(ITicketService service) : CommonController
{
    [HttpGet]
    public async Task<ActionResult<List<TicketDto>>> GetAllTickets()
    {
        var res = await service.GetTicketsAsync();
        return PrepareResult(res);
    }
    
    [HttpGet("{id:long}")]
    public async Task<ActionResult<TicketDto>> GetTicket([FromRoute] long id)
    {
        var res = await service.GetTicketAsync(id);
        return PrepareResult(res);
    }
    
    [HttpPost]
    public async Task<ActionResult<long>> CreateTicket([FromBody] CreateTicketDto ticket)
    {
        var res = await service.CreateTicketAsync(ticket);
        return PrepareResult(res);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateTicket([FromRoute] int id, [FromBody] UpdateTicketDto ticket)
    {
        var res = await service.UpdateTicketAsync(id, ticket);
        return PrepareResult(res);
    }
}