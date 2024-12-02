namespace BusinessLayer.Dtos.Response;

public class UserCheckModel
{
    public Guid UserId { get; set; }
    public string? Role { get; set; }
    public bool IsProfileComplete { get; set; }
}