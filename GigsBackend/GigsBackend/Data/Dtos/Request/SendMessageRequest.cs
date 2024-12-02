namespace BusinessLayer.Dtos.Request;

public class SendMessageRequest
{
    public Guid GigId { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string? Content { get; set; }
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}