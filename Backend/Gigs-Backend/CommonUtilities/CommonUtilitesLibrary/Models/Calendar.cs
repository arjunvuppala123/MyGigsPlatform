namespace CommonUtilitesLibrary.Models
{
    public class Calendar
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [MaxLength(50)]
        public string ExternalService { get; set; } = null!;

        public string CalendarLink { get; set; } = null!;

        public DateTime SyncedAt { get; set; } = DateTime.Now;

        public User User { get; set; } = null!;
    }
}
