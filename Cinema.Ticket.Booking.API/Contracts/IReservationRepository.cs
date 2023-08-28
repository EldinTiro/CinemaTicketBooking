using Cinema.Ticket.Booking.API.Data;
using Cinema.Ticket.Booking.API.Models;

namespace Cinema.Ticket.Booking.API.Contracts;

public interface IReservationRepository: IGenericRepository<Reservation>
{
    Task<Reservation> SeatReservation(Reservation reservation);
}