using Cinema.Ticket.Booking.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Ticket.Booking.API.Data.Configurations;

public class MovieConfiguration: IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasData(
            new Movie
            {
                Id = 1,
                Title = "Batman",
                Description = "Batman need description?",
                Genre = "Crime",
                Duration = 2.5
            },
            new Movie
            {
                Id = 2,
                Title = "Superman",
                Description = "Superman need description?",
                Genre = "Adventure",
                Duration = 3.0
            });
    }
}