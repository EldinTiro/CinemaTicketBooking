using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.Ticket.Booking.API.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Ticket.Booking.API.Data;
using Cinema.Ticket.Booking.API.Models;
using Cinema.Ticket.Booking.API.Models.Movies;
using Cinema.Ticket.Booking.API.Models.Reservation;

namespace Cinema.Ticket.Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;

        public ReservationsController(IMapper mapper, IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            var records = _mapper.Map<List<GetReservationDto>>(reservations);
            return Ok(records);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<GetReservationDto>> GetReservation(int id)
        {
            var reservation = await _reservationRepository.GetAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }
            
            var reservationDto = _mapper.Map<GetReservationDto>(reservation);

            return Ok(reservationDto);
        }
        
        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(CreateReservationDto createReservationDto)
        {
            var reservation = _mapper.Map<Reservation>(createReservationDto);

            await _reservationRepository.SeatReservation(reservation);
            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _reservationRepository.GetAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            await _reservationRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
