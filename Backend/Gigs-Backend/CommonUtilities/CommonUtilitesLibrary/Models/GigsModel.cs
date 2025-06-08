namespace CommonUtilitesLibrary.Models
{
    [Table("gigs")]
    public class Gig
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("freelancer_id")]
        public Guid FreelancerId { get; set; }

        [Required]
        [Column("category_id")]
        public Guid CategoryId { get; set; }

        [Required]
        [Column("currency_id")]
        public Guid CurrencyId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("title")]
        public string Title { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("price", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Column("availability", TypeName = "nvarchar(max)")]
        public string? Availability { get; set; }

        [Column("gallery")]
        public string? Gallery { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("FreelancerId")]
        public User Freelancer { get; set; } = null!;
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; } = null!;
        public List<PricingTier> PricingTiers { get; set; } = new List<PricingTier>();
        public List<TimeSlotTier> TimeSlotTiers { get; set; } = new List<TimeSlotTier>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
