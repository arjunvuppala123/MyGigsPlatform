namespace CommonUtilitesLibrary.Models
{
    [Table("reviews")]
    public class Review
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

        [Column("rating")]
        public int? Rating { get; set; }

        [Column("review_text")]
        public string? ReviewText { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("GigId")]
        public Gig Gig { get; set; } = null!;
        [ForeignKey("ClientId")]
        public User Client { get; set; } = null!;
    }
}
