using Cinema.Ticket.Booking.API.Contracts;
using Cinema.Ticket.Booking.API.Data;

namespace Cinema.Ticket.Booking.API.Repository;

public class MoviesRepository : GenericRepository<Movie>, IMovieRepository
{
    private readonly CinemaTicketBookingDbContext _context;

    public MoviesRepository(CinemaTicketBookingDbContext context) : base(context)
    {
        _context = context;
    }
}