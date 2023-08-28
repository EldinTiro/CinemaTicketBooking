namespace Cinema.Ticket.Booking.API.Models.ShowTime;

public class BaseShowTimeDto
{
    public DateTime DateTime { get; set; }
    public int MovieId { get; set; }
    public int TheaterId { get; set; }
}