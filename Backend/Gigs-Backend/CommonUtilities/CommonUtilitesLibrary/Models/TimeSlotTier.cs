namespace CommonUtilitesLibrary.Models
{
    [Table("time_slot_tiers")]
    public class TimeSlotTier
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("gig_id")]
        public Guid GigId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("slot_name")]
        public string SlotName { get; set; } = null!;

        [Required]
        [Column("start_time")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Column("end_time")]
        public TimeSpan EndTime { get; set; }

        [Required]
        [Column("duration_minutes")]
        public int DurationMinutes { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("GigId")]
        public Gig Gig { get; set; } = null!;
    }
}
