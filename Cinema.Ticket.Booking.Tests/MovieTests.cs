using Cinema.Ticket.Booking.API.Data;
using Cinema.Ticket.Booking.API.Repository;

namespace Cinema.Ticket.Booking.Tests;

public class MovieTests
{
    private readonly CinemaTicketBookingDbContext _context;
    public MovieTests()
    {
        _context = ContextGenerator.Generate();
    }

    #region Movie Tests
    [Fact]
    public async Task MovieCreationTesting()
    {
        //Arrange
        var moviesRepository = new MoviesRepository(_context);
        
        //Act
        await moviesRepository.AddAsync(new Movie());

        //Assert
        Assert.Single(_context.Movies);
    }
    
    [Fact]
    public async Task DeleteMovie()
    {
        //Arrange
        var moviesRepository = new MoviesRepository(_context);
        
        //Act
        var movie = await moviesRepository.AddAsync(new Movie());
        await moviesRepository.DeleteAsync(movie.Id);

        //Assert
        Assert.Empty(_context.Movies);
    }
    
    [Theory]
    [InlineData("Batman 2", 3.5)]
    [InlineData("The Dark Knight", 4)]
    [InlineData("Inception", 2.5)]
    [InlineData("Forrest Gump", 4.2)]
    public async Task UpdateMovie(string newTitleValue, double newDurationValue)
    {
        //Arrange
        var moviesRepository = new MoviesRepository(_context);
        
        //Act
        var movie = await moviesRepository.AddAsync(new Movie { Id = 1, Description = "Description", Duration = 2.5, Title = "Batman"});
        movie.Title = newTitleValue;
        movie.Duration = newDurationValue;
        
        await moviesRepository.UpdateAsync(movie);
        
        var updatedMovie = await moviesRepository.GetAsync(movie.Id);

        //Assert
        Assert.Equal(updatedMovie.Title, newTitleValue);
        Assert.Equal(updatedMovie.Duration, newDurationValue);
    }
    #endregion
}