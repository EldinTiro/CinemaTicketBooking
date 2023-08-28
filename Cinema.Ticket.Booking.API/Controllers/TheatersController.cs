using AutoMapper;
using Cinema.Ticket.Booking.API.Contracts;
using Cinema.Ticket.Booking.API.Data;
using Cinema.Ticket.Booking.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Ticket.Booking.API.Models;
using Cinema.Ticket.Booking.API.Models.Theaters;

namespace Cinema.Ticket.Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITheaterRepository _theaterRepository;

        public TheatersController(IMapper mapper, ITheaterRepository repository)
        {
            _mapper = mapper;
            _theaterRepository = repository;
        }

        // GET: api/Theaters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTheaterDto>>> GetTheaters()
        {
            var theater = await _theaterRepository.GetAllAsync();
            var records = _mapper.Map<List<GetTheaterDto>>(theater);
            return Ok(records);
        }

        // GET: api/Theaters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTheaterDto>> GetTheater(int id)
        {
            var theater = await _theaterRepository.GetAsync(id);

            if (theater == null)
            {
                throw new NotFoundException(nameof(GetTheater), id);
            }

            var theaterDto = _mapper.Map<GetTheaterDto>(theater);

            return Ok(theaterDto);
        }

        // PUT: api/Theaters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheater(int id, UpdateTheaterDto updateTheaterDto)
        {
            if (id != updateTheaterDto.Id)
            {
                return BadRequest();
            }

            var theater = await _theaterRepository.GetAsync(id);

            if (theater == null)
            {
                throw new NotFoundException(nameof(GetTheater), id);
            }

            _mapper.Map(updateTheaterDto, theater);

            try
            {
                await _theaterRepository.UpdateAsync(theater);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TheaterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Theaters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Theater>> PostTheater(CreateTheaterDto createTheaterDto)
        {
            var theater = _mapper.Map<Theater>(createTheaterDto);

            await _theaterRepository.AddAsync(theater);
            return CreatedAtAction("GetTheater", new { id = theater.Id }, theater);
        }

        // DELETE: api/Theaters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheater(int id)
        {
            var theater = await _theaterRepository.GetAsync(id);
            if (theater == null)
            {
                throw new NotFoundException(nameof(GetTheater), id);
            }
            
            await _theaterRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> TheaterExists(int id)
        {
            return await _theaterRepository.Exists(id);
        }
    }
}
