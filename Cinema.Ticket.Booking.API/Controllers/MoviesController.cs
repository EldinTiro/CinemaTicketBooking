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
using Cinema.Ticket.Booking.API.Exceptions;
using Cinema.Ticket.Booking.API.Models;
using Cinema.Ticket.Booking.API.Models.Movies;

namespace Cinema.Ticket.Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMapper mapper, IMovieRepository repository)
        {
            _mapper = mapper;
            _movieRepository = repository;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetMovieDto>>> GetMovies()
        {
            var movies = await _movieRepository.GetAllAsync();
            var records = _mapper.Map<List<GetMovieDto>>(movies);
            return Ok(records);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetMovieDto>> GetMovie(int id)
        {
            var movie = await _movieRepository.GetAsync(id);

            if (movie == null)
            {
                throw new NotFoundException(nameof(GetMovie), id);
            }

            var movieDto = _mapper.Map<GetMovieDto>(movie);

            return Ok(movieDto);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, UpdateMovieDto updateMovieDto)
        {
            if (id != updateMovieDto.Id)
            {
                return BadRequest();
            }

            var movie = await _movieRepository.GetAsync(id);

            if (movie == null)
            {
                throw new NotFoundException(nameof(GetMovie), id);
            }

            _mapper.Map(updateMovieDto, movie);

            try
            {
                await _movieRepository.UpdateAsync(movie);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MovieExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(CreateMovieDto createMovieDto)
        {
            var movie = _mapper.Map<Movie>(createMovieDto);

            await _movieRepository.AddAsync(movie);
            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieRepository.GetAsync(id);
            if (movie == null)
            {
                throw new NotFoundException(nameof(GetMovie), id);
            }

            await _movieRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> MovieExists(int id)
        {
            return await _movieRepository.Exists(id);
        }
    }
}
