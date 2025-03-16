using CommonObjects;
using Services.Contracts;

namespace Services;

public class MethodResponse<T> : IMethodResponse<T>
{
    public bool Result { get; }

    public OperationStatus Status { get; }

    public ErrorObject? Error { get; }

    public T? Data { get; }

    private MethodResponse(bool result, OperationStatus status, T payload)
    {
        Result = result;
        Status = status;
        Data = payload;
    }

    private MethodResponse(bool result, OperationStatus status, ErrorObject error)
    {
        Result = result;
        Error = error;
        Status = status;
    }

    public static MethodResponse<T> Success(T result)
    {
        return new MethodResponse<T>(true, OperationStatus.Success, result);
    }

    public static MethodResponse<T> Created(T result)
    {
        return new MethodResponse<T>(true, OperationStatus.Created, result);
    }

    public static MethodResponse<T> Failure(string code, string message)
    {
        return new MethodResponse<T>(false, OperationStatus.Failure, new ErrorObject(code, message));
    }

    public static MethodResponse<T> NotFound(string message = "Resource not found")
    {
        return new MethodResponse<T>(false, OperationStatus.NotFound, new ErrorObject(ApiErrorCode.ResourceNotFound, message));
    }
}

public class MethodResponse : IMethodResponse
{
    public bool Result { get; set; }
    public OperationStatus Status { get; set; }
    public ErrorObject? Error { get; set; }
    
    public MethodResponse(bool result, OperationStatus status, ErrorObject error)
    {
        Result = result;
        Error = error;
        Status = status;
    }
    
    public MethodResponse(bool result, OperationStatus status)
    {
        Result = result;
        Status = status;
    }
    
    public static MethodResponse Success()
    {
        return new MethodResponse(true, OperationStatus.Success);
    }
    
    public static MethodResponse NoContent()
    {
        return new MethodResponse(true, OperationStatus.NoContent);
    }

    public static MethodResponse Failure(string code, string message)
    {
        return new MethodResponse(false, OperationStatus.Failure, new ErrorObject(code, message));
    }
}