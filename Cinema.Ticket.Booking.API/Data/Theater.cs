namespace Cinema.Ticket.Booking.API.Data;
public class Theater
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    // Navigation property for seating arrangement
    public IList<Seat> Seats { get; set; }

    // Navigation property for related showtimes
    public IList<Showtime> Showtimes { get; set; }
}
