using System.ComponentModel.DataAnnotations;
using NuGet.Packaging.Signing;

namespace Cinema.Ticket.Booking.API.Models.Movies;

public class BaseMovieDto
{
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required(ErrorMessage = "Duration is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Duration must be greater than 0.")]
    public Double Duration { get; set; }
    public string Genre { get; set; }
}