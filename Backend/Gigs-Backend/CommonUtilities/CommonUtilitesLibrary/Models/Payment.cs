using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonUtilitesLibrary.Models
{
    [Table("payments")]
    public class Payment
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("booking_id")]
        public Guid BookingId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("payment_gateway")]
        public string PaymentGateway { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [Column("payment_reference")]
        public string PaymentReference { get; set; } = null!;

        [Required]
        [Column("amount", TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column("currency_id")]
        public Guid CurrencyId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("status")]
        public string Status { get; set; } = null!;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; } = null!;
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; } = null!;
    }
}
