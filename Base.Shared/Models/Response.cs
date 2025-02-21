namespace Base.Shared.Models;

public class Response
{
    public bool Success { get; set; }
    public List<string> Messages { get; set; } = [];
    public Guid? EntityId { get; set; }
}

public class Response<T>
{
    public bool Success { get; set; }
    public List<string> Messages { get; set; } = [];
    public T? Data { get; set; }
    public Guid? EntityId { get; set; }
}