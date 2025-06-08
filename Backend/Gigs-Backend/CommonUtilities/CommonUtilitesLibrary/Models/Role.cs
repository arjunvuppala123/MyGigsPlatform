namespace CommonUtilitesLibrary.Models
{
    public class Role
    {
        public Guid Id { get; set; }

        public string RoleCode { get; set; } = null!;

        public string RoleDescription { get; set; } = null!;

        public List<User> Users { get; set; } = new List<User>();
    }
}
