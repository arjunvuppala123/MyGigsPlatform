namespace BusinessLayer.Dtos.Request;

public class SaveUser
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public Guid GenderId { get; set; }
    public Guid RoleId { get; set; }
    public bool IsUserProfileComplete { get; set; } = true;
}