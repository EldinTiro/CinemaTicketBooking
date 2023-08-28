using Cinema.Ticket.Booking.API.Contracts;
using Cinema.Ticket.Booking.API.Data;
using Cinema.Ticket.Booking.API.Exceptions;
using Cinema.Ticket.Booking.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Ticket.Booking.API.Repository;

public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
{
    private readonly CinemaTicketBookingDbContext _context;

    public ReservationRepository(CinemaTicketBookingDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Reservation> SeatReservation(Reservation request)
    {
        if (!await DoesSeatExist(request.SeatId, request.ShowtimeId))
        {
            throw new NotFoundException("The chosen seat does not exist in the selected ShowTime Theater.", request.SeatId); // Globally handled
        }

        if (await IsSeatTaken(request.SeatId, request.ShowtimeId))
        {
            throw new InvalidOperationException("The chosen seat is already reserved for the selected ShowTime."); // Globally handled
        }

        await AddReservationAsync(request);
        return request;
    }

    private async Task<bool> DoesSeatExist(int seatId, int showtimeId)
    {
        return await _context.Reservations
            .AnyAsync(q => q.Showtime.Theater.Seats.Any(s => s.Id == seatId));
    }

    private async Task<bool> IsSeatTaken(int seatId, int showtimeId)
    {
        return await _context.Reservations
            .AnyAsync(q => q.SeatId == seatId && q.ShowtimeId == showtimeId);
    }

    private async Task AddReservationAsync(Reservation request)
    {
        await _context.AddAsync(request);
        await _context.SaveChangesAsync();
    }
}