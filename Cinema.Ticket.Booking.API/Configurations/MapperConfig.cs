using AutoMapper;
using Cinema.Ticket.Booking.API.Data;
using Cinema.Ticket.Booking.API.Models.Movies;
using Cinema.Ticket.Booking.API.Models.Reservation;
using Cinema.Ticket.Booking.API.Models.ShowTime;
using Cinema.Ticket.Booking.API.Models.Theaters;

namespace Cinema.Ticket.Booking.API.Configurations;

public class MapperConfig: Profile
{
    public MapperConfig()
    {
        CreateMap<Movie, CreateMovieDto>().ReverseMap();
        CreateMap<Movie, GetMovieDto>().ReverseMap();
        CreateMap<Movie, UpdateMovieDto>().ReverseMap();
        
        CreateMap<Theater, CreateTheaterDto>().ReverseMap();
        CreateMap<Theater, GetTheaterDto>().ReverseMap();
        CreateMap<Theater, UpdateTheaterDto>().ReverseMap();
        
        CreateMap<Showtime, CreateShowTImeDto>().ReverseMap();
        CreateMap<Showtime, GetShowTimeDto>().ReverseMap();
        CreateMap<Showtime, UpdateShowTimeDto>().ReverseMap();
        
        CreateMap<Reservation, CreateReservationDto>().ReverseMap();
        CreateMap<Reservation, GetReservationDto>().ReverseMap();
    }
}