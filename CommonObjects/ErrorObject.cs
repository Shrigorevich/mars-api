namespace CommonObjects;

public class ErrorObject(string code, string message)
{
    public string Code { get; set; } = code;
    public string Message { get; set; } = message;
}