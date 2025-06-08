namespace CommonUtilitesLibrary.Models
{
    [Table("pricing_tiers")]
    public class PricingTier
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("gig_id")]
        public Guid GigId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("tier_name")]
        public string TierName { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("price", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column("delivery_time")]
        public int DeliveryTime { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("GigId")]
        public Gig Gig { get; set; } = null!;
    }
}
