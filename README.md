# CinemaTicketBooking

## Start steps:

Navigate to the root directory and using the docker-compose command, start the local db instance of the Postgres

```bash
docker-compose up
```

To build the application using .NET CLI, run the command:
```bash
dotnet build
```

Update the database with already generated migrations using the .NET CLI command:
Note: By updating db some initial data will be seeded as well

```bash
dotnet ef database update
```

To run the application using .NET CLI, run the command:
```bash
dotnet run
```

## Some request examples:
### To Create a Movie:
[Method: POST](https://localhost:7044/api/Movies)
```json
{
  "title": "The Shawshank Redemption",
  "description": "Two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion",
  "duration": 3.5,
  "genre": "Drama"
}
```

### To Create a Theater:
[Method: POST](https://localhost:7044/api/Theaters)
```json
{
  "name": "EXTREME",
  "location": "London"
}
```

### To Create a ShowTime:
[Method: POST](https://localhost:7044/api/ShowTimes)
```json
{
  "dateTime": "2023-10-31T20:30:00.000Z",
  "movieId": 1,
  "theaterId": 1
}
```

### To Create a Reservation:
[Method: POST](https://localhost:7044/api/ShowTimes)
```json
{
  "showtimeId": 2,
  "seatId": 3
}
```

#Features and best practices that are implemented inside the project:
1. Code-First approach
2. Seeding initial data
3. Scaffolding controllers from Entities
4. AutoMapping DTOs to Entity models and reverse with Automapper
5. DataTransferObjects with DataAnotation validation
6. Creating and building Postgress DB using docker (docker-compose)
7. Global exception handlers
8. Repository pattern as an abstraction between the intelligence and controller layers
9. Unit test using xUnit library with InMemoryDb
...

#What could be improved:
1. More validations and handled exceptions to avoid 500 errors
2. Using Architecture design patter such is (Clean architecture, Onion, N-tier...)
3. Adding logs (for example Log4Net)
