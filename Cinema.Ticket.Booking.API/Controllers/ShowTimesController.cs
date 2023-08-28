using AutoMapper;
using Cinema.Ticket.Booking.API.Contracts;
using Cinema.Ticket.Booking.API.Data;
using Microsoft.AspNetCore.Mvc;
using Cinema.Ticket.Booking.API.Models.ShowTime;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Ticket.Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShowTimeRepository _showTimeRepository;

        public ShowTimesController(IMapper mapper, IShowTimeRepository showTimeRepository)
        {
            _mapper = mapper;
            _showTimeRepository = showTimeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetShowTimeDto>>> GetShowTimes()
        {
            var showTimes = await _showTimeRepository.GetAllAsync();
            var records = _mapper.Map<List<GetShowTimeDto>>(showTimes);
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetShowTimeDto>> GetShowtime(int id)
        {
            var showtime = await _showTimeRepository.GetAsync(id);

            if (showtime == null)
            {
                return NotFound();
            }
            
            var showTimeDto = _mapper.Map<GetShowTimeDto>(showtime);

            return Ok(showTimeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShowtime(int id, UpdateShowTimeDto updateShowTimeDto)
        {
            if (id != updateShowTimeDto.Id)
            {
                return BadRequest();
            }

            var showtime = await _showTimeRepository.GetAsync(id);

            if (showtime == null)
            {
                return NotFound();
            }

            _mapper.Map(updateShowTimeDto, showtime);

            try
            {
                await _showTimeRepository.UpdateAsync(showtime);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ShowtimeExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Showtime>> PostShowtime(CreateShowTImeDto createShowTImeDto)
        {
            var showtime = _mapper.Map<Showtime>(createShowTImeDto);

            await _showTimeRepository.AddAsync(showtime);
            return CreatedAtAction("GetShowtime", new { id = showtime.Id }, showtime);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShowtime(int id)
        {
            var showtime = await _showTimeRepository.GetAsync(id);
            if (showtime == null)
            {
                return NotFound();
            }

            await _showTimeRepository.DeleteAsync(id);
            return NoContent();
        }
        
        private async Task<bool> ShowtimeExists(int id)
        {
            return await _showTimeRepository.Exists(id);
        }
    }
}
