namespace CommonUtilitesLibrary.Models
{
    [Table("messages")]
    public class Message
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("gig_id")]
        public Guid GigId { get; set; }

        [Required]
        [Column("sender_id")]
        public Guid SenderId { get; set; }

        [Required]
        [Column("message_content")]
        public string MessageContent { get; set; } = null!;

        [Column("sent_at")]
        public DateTime SentAt { get; set; } = DateTime.Now;

        [ForeignKey("GigId")]
        public Gig Gig { get; set; } = null!;

        [ForeignKey("SenderId")]
        public User Sender { get; set; } = null!;
    }
}
