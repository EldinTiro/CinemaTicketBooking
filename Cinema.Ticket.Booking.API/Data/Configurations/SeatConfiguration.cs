using Cinema.Ticket.Booking.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Ticket.Booking.API.Data.Configurations;

public class SeatConfiguration: IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.HasData(
            new Seat
            {
                Id = 1,
                TheaterId = 1,
                SeatNumber = "A-1",
            },
            new Seat
            {
                Id = 2,
                TheaterId = 1,
                SeatNumber = "A-2",
            },
            new Seat
            {
                Id = 3,
                TheaterId = 1,
                SeatNumber = "B-1",
            },
            new Seat
            {
                Id = 4,
                TheaterId = 1,
                SeatNumber = "B-2",
            },
            new Seat
            {
                Id = 5,
                TheaterId = 2,
                SeatNumber = "A-1",
            },
            new Seat
            {
                Id = 6,
                TheaterId = 2,
                SeatNumber = "A-2",
            },
            new Seat
            {
                Id = 7,
                TheaterId = 2,
                SeatNumber = "B-1",
            },
            new Seat
            {
                Id = 8,
                TheaterId = 2,
                SeatNumber = "B-2",
            });
    }
}