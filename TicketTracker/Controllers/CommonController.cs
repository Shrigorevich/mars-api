using CommonObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace TicketTracker.Controllers;

public class CommonController : ControllerBase
{
    protected ActionResult PrepareResult<T>(IMethodResponse<T> response)
    {
        return response.Result ? StatusCode(GetStatus(response.Status), response.Data) : StatusCode(GetStatus(response.Status), response.Error);
    }
    
    protected ActionResult PrepareResult(IMethodResponse response)
    {
        return response.Result ? StatusCode(GetStatus(response.Status)) : StatusCode(GetStatus(response.Status), response.Error);
    }

    private static int GetStatus(OperationStatus status)
    {
        return status switch
        {
            OperationStatus.Success => 200,
            OperationStatus.Failure => 400,
            OperationStatus.Created => 201,
            OperationStatus.NotFound => 404,
            OperationStatus.NoContent => 204,
            _ => 200
        };
    }
}