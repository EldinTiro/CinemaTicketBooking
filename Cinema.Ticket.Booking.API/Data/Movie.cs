namespace Cinema.Ticket.Booking.API.Data;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Double Duration { get; set; }
    public string Genre { get; set; }

    // Navigation property for related showtimes
    public IList<Showtime> Showtimes { get; set; }
}
