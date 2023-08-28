using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Ticket.Booking.API.Data;

public class Showtime
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    [ForeignKey(nameof(MovieId))]
    public int MovieId { get; set; }
    [ForeignKey(nameof(TheaterId))]
    public int TheaterId { get; set; }
    public int AvailableSeats { get; set; }

    // Navigation properties for related movie and theater
    public Movie Movie { get; set; }
    public Theater Theater { get; set; }

    // Navigation property for related reservations
    public IList<Reservation> Reservations { get; set; }
}

