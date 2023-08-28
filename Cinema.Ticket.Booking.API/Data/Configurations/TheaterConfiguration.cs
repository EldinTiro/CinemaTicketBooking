using Cinema.Ticket.Booking.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Ticket.Booking.API.Data.Configurations;

public class TheaterConfiguration: IEntityTypeConfiguration<Theater>
{
    public void Configure(EntityTypeBuilder<Theater> builder)
    {
        builder.HasData(
            new Theater
            {
                Id = 1,
                Location = "Somewhere in Berlin",
                Name = "Basic",
            },
            new Theater
            {
                Id = 2,
                Location = "Somewhere in Berlin",
                Name = "IMAX"
            });
    }
}