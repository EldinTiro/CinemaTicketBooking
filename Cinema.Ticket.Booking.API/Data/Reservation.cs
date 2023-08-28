namespace Cinema.Ticket.Booking.API.Data;

public class Reservation
{
    public int Id { get; set; }
    public int ShowtimeId { get; set; }
    public int SeatId { get; set; }

    // Navigation properties for related user and showtime
    public Showtime Showtime { get; set; }

    public IList<Seat> ReservedSeats { get; set; }
}
