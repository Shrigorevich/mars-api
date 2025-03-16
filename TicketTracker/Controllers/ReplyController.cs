using Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace TicketTracker.Controllers;

[ApiController]
[Route("api/v1/tickets/{ticketId:long}/replies")]
public class ReplyController(IReplyService service) : CommonController
{
    [HttpGet]
    public async Task<ActionResult<List<TicketReplyDto>>> GetAllReplies([FromRoute] long ticketId)
    {
        var res = await service.GetRepliesAsync(ticketId);
        return PrepareResult(res);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TicketReplyDto>> GetReply([FromRoute] int id)
    {
        var res = await service.GetReplyAsync(id);
        return PrepareResult(res);
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> CreateReply([FromRoute] long ticketId, [FromBody] CreateTicketReplyDto reply)
    {
        var res = await service.CreateReplyAsync(ticketId, reply);
        return PrepareResult(res);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateReply([FromRoute] int id, [FromBody] UpdateTicketReplyDto reply)
    {
        var res = await service.UpdateReplyAsync(id, reply);
        return PrepareResult(res);
    }
}