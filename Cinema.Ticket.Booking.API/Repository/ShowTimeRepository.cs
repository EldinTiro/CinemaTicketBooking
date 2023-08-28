using Cinema.Ticket.Booking.API.Contracts;
using Cinema.Ticket.Booking.API.Data;
using Cinema.Ticket.Booking.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Ticket.Booking.API.Repository;

public class ShowTimeRepository : GenericRepository<Showtime>, IShowTimeRepository
{
    private readonly CinemaTicketBookingDbContext _context;

    public ShowTimeRepository(CinemaTicketBookingDbContext context) : base(context)
    {
        _context = context;
    }
}