namespace Cinema.Ticket.Booking.API.Data;
public class Seat
{
    public int Id { get; set; }
    public string SeatNumber { get; set; }
    public int TheaterId { get; set; }

    // Navigation property for related theater
    public Theater Theater { get; set; }
}
