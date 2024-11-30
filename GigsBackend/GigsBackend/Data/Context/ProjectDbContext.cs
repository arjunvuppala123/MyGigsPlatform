using DbLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options): base(options){
    }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Gig> Gigs { get; set; }
    public DbSet<Message?> Messages { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Gender> Genders { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    // User -> Role relationship
    modelBuilder.Entity<User>()
        .HasOne(u => u.Role)
        .WithMany() // No back-reference in Role
        .HasForeignKey(u => u.RoleId)
        .OnDelete(DeleteBehavior.Cascade);

    // User -> Gender relationship
    modelBuilder.Entity<User>()
        .HasOne(u => u.Gender)
        .WithMany() // No back-reference in Gender
        .HasForeignKey(u => u.GenderId)
        .OnDelete(DeleteBehavior.Cascade);

    // Gig -> Freelancer (User) relationship
    modelBuilder.Entity<Gig>()
        .HasOne(g => g.Freelancer)
        .WithMany() // Assuming no back-reference in User
        .HasForeignKey(g => g.FreelancerId)
        .OnDelete(DeleteBehavior.Cascade);

    // Gig -> Client (User) relationship
    modelBuilder.Entity<Gig>()
        .HasOne(g => g.Client)
        .WithMany() // Assuming no back-reference in User
        .HasForeignKey(g => g.ClientId)
        .OnDelete(DeleteBehavior.Cascade);

    // Gig -> Category relationship
    modelBuilder.Entity<Gig>()
        .HasOne(g => g.Category)
        .WithMany()
        .HasForeignKey(g => g.CategoryId)
        .OnDelete(DeleteBehavior.Cascade);

    // Gig -> Currency relationship
    modelBuilder.Entity<Gig>()
        .HasOne(g => g.Currency)
        .WithMany()
        .HasForeignKey(g => g.CurrencyId)
        .OnDelete(DeleteBehavior.Cascade);

    // Booking -> Gig relationship
    modelBuilder.Entity<Booking>()
        .HasOne(b => b.Gig)
        .WithMany()
        .HasForeignKey(b => b.GigId)
        .OnDelete(DeleteBehavior.Cascade);

    // Booking -> Client (User) relationship
    modelBuilder.Entity<Booking>()
        .HasOne(b => b.Client)
        .WithMany()
        .HasForeignKey(b => b.ClientId)
        .OnDelete(DeleteBehavior.Cascade);

    // Booking -> Currency relationship
    modelBuilder.Entity<Booking>()
        .HasOne(b => b.Currency)
        .WithMany()
        .HasForeignKey(b => b.CurrencyId)
        .OnDelete(DeleteBehavior.Cascade);

    // Payment -> Booking relationship
    modelBuilder.Entity<Payment>()
        .HasOne(p => p.Booking)
        .WithMany()
        .HasForeignKey(p => p.BookingId)
        .OnDelete(DeleteBehavior.Cascade);

    // Payment -> Currency relationship
    modelBuilder.Entity<Payment>()
        .HasOne(p => p.Currency)
        .WithMany()
        .HasForeignKey(p => p.CurrencyId)
        .OnDelete(DeleteBehavior.Cascade);

    // Review -> Gig relationship
    modelBuilder.Entity<Review>()
        .HasOne(r => r.Gig)
        .WithMany()
        .HasForeignKey(r => r.GigId)
        .OnDelete(DeleteBehavior.Cascade);

    // Review -> Client (User) relationship
    modelBuilder.Entity<Review>()
        .HasOne(r => r.Client)
        .WithMany()
        .HasForeignKey(r => r.ClientId)
        .OnDelete(DeleteBehavior.Cascade);

    // Message -> Gig relationship
    modelBuilder.Entity<Message>()
        .HasOne(m => m.Gig)
        .WithMany()
        .HasForeignKey(m => m.GigId)
        .OnDelete(DeleteBehavior.Cascade);

    // Message -> Sender (User) relationship
    modelBuilder.Entity<Message>()
        .HasOne(m => m.Sender)
        .WithMany()
        .HasForeignKey(m => m.SenderId)
        .OnDelete(DeleteBehavior.Cascade);

    // Message -> Receiver (User) relationship
    modelBuilder.Entity<Message>()
        .HasOne(m => m.Receiver)
        .WithMany()
        .HasForeignKey(m => m.RecieverId)
        .OnDelete(DeleteBehavior.Cascade);
    
    // Calendar -> User relationship
    modelBuilder.Entity<Calendar>()
        .HasOne(c => c.User)
        .WithMany()
        .HasForeignKey(c => c.UserId)
        .OnDelete(DeleteBehavior.Cascade);

    base.OnModelCreating(modelBuilder);
    }
}