namespace CommonUtilitesLibrary.Models
{
    [Table("currencies")]
    public class Currency
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("code")]
        public string Code { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [Column("name")]
        public string Name { get; set; } = null!;

        public List<Gig> Gigs { get; set; } = new List<Gig>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public List<Payment> Payments { get; set; } = new List<Payment>();
    }
}
