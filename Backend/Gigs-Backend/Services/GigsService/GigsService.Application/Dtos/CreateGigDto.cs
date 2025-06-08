namespace GigsService.Application.Dtos
{
    public record CreateGigDto
    {
        public Guid FreelancerId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CurrencyId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Availability { get; set; }
        public string? Gallery { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
