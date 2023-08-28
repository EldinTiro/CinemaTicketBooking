using Cinema.Ticket.Booking.API.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Ticket.Booking.API.Data;

public class CinemaTicketBookingDbContext: DbContext
{
    public CinemaTicketBookingDbContext(DbContextOptions options): base(options)
    {
        
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Theater> Theaters { get; set; }
    public DbSet<Showtime> ShowTimes { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
        modelBuilder.ApplyConfiguration(new TheaterConfiguration());
        modelBuilder.ApplyConfiguration(new SeatConfiguration());
    }
}