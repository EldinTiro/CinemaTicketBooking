using Cinema.Ticket.Booking.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Ticket.Booking.Tests;

public static class ContextGenerator
{
    public static CinemaTicketBookingDbContext Generate()
    {
        var optionBuilder = new DbContextOptionsBuilder<CinemaTicketBookingDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());

        return new CinemaTicketBookingDbContext(optionBuilder.Options);
    }
}