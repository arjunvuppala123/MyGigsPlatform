namespace CommonUtilitesLibrary.Models
{
    [Table("bookings")]
    public class Booking
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("gig_id")]
        public Guid GigId { get; set; }

        [Required]
        [Column("client_id")]
        public Guid ClientId { get; set; }

        [Required]
        [Column("pricing_tier_id")]
        public Guid PricingTierId { get; set; }

        [Required]
        [Column("time_slot_id")]
        public Guid TimeSlotId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("status")]
        public string Status { get; set; } = null!;

        [Required]
        [Column("scheduled_at")]
        public DateTime ScheduledAt { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("payment_status")]
        public string PaymentStatus { get; set; } = null!;

        [Required]
        [Column("amount", TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column("currency_id")]
        public Guid CurrencyId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("GigId")]
        public Gig Gig { get; set; } = null!;
        [ForeignKey("ClientId")]
        public User Client { get; set; } = null!;
        [ForeignKey("PricingTierId")]
        public PricingTier PricingTier { get; set; } = null!;
        [ForeignKey("TimeSlotId")]
        public TimeSlotTier TimeSlot { get; set; } = null!;
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; } = null!;
    }
}
