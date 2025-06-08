namespace CommonUtilitesLibrary.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Gig> Gigs { get; set; } = new List<Gig>();
    }
}
