namespace IgrejaApp.Domain.DTOs.Requests;

public class LogRequest
{
    public LogRequest()
    {
    }

    public LogRequest(string message, string title, DateTime createDate, Guid? userId, string version)
    {
        Message = message;
        Title = title;
        CreateDate = createDate;
        UserId = userId;
        Version = version;
    }

    public string Message { get; set; }
    public string Title { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public Guid? UserId { get; set; }
    public string Version { get; set; }
    public LogRequest[] Logs { get; set; }
}