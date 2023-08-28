namespace Cinema.Ticket.Booking.API.Exceptions;

public class NotFoundException: ApplicationException
{
    public NotFoundException(string name, object key): base($"{name} ({key}) was not found")
    {
        
    }
}