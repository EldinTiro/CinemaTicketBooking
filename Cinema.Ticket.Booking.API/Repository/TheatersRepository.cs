using Cinema.Ticket.Booking.API.Contracts;
using Cinema.Ticket.Booking.API.Data;
using Cinema.Ticket.Booking.API.Models;

namespace Cinema.Ticket.Booking.API.Repository;

public class TheatersRepository : GenericRepository<Theater>, ITheaterRepository
{
    private readonly CinemaTicketBookingDbContext _context;

    public TheatersRepository(CinemaTicketBookingDbContext context) : base(context)
    {
        _context = context;
    }
}