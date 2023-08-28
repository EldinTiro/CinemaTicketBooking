using Cinema.Ticket.Booking.API.Data;
using Cinema.Ticket.Booking.API.Repository;

namespace Cinema.Ticket.Booking.Tests;

public class TheaterTests
{
    private readonly CinemaTicketBookingDbContext _context;
    public TheaterTests()
    {
        _context = ContextGenerator.Generate();
    }

    #region Theater tests
    [Fact]
    public async Task TheaterCreation()
    {
        //Arrange
        var theatersRepository = new TheatersRepository(_context);
        
        //Act
        await theatersRepository.AddAsync(new Theater());

        //Assert
        Assert.Single(_context.Theaters);
    }
    
    [Fact]
    public async Task DeleteTheater()
    {
        //Arrange
        var theatersRepository = new TheatersRepository(_context);
        
        //Act
        var theater = await theatersRepository.AddAsync(new Theater());
        await theatersRepository.DeleteAsync(theater.Id);

        //Assert
        Assert.Empty(_context.Theaters);
    }
    
    [Theory]
    [InlineData("Manchester", "4DX")]
    [InlineData("London", "IMAX")]
    [InlineData("Liverpool", "EXTREME")]
    public async Task UpdateTheater(string newLocationValue, string newNameValue)
    {
        //Arrange
        var theatersRepository = new TheatersRepository(_context);
        
        //Act
        var theater = await theatersRepository.AddAsync(new Theater() { Id = 1, Location = "Leeds", Name = "BASIC"});
        theater.Location = newLocationValue;
        theater.Name = newNameValue;
        
        await theatersRepository.UpdateAsync(theater);
        
        var updatedTheater = await theatersRepository.GetAsync(theater.Id);

        //Assert
        Assert.Equal(updatedTheater.Location, newLocationValue);
        Assert.Equal(updatedTheater.Name, newNameValue);
    }
    

    #endregion
}