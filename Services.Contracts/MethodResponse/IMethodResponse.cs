namespace Services.Contracts;

public interface IMethodResponse<out T>
{
    bool Result { get; }

    OperationStatus Status { get; }

    ErrorObject? Error { get; }

    T? Data { get; }
}

public interface IMethodResponse
{
    bool Result { get; }
    OperationStatus Status { get; }
    ErrorObject? Error { get; }
}