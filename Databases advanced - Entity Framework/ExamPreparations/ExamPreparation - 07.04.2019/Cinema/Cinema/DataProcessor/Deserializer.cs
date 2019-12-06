namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            ImportMovieDto[] moviesDtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var movieDto in moviesDtos)
            {
                if (IsValid(movieDto))
                {
                    Movie movie = new Movie()
                    {
                        Title = movieDto.Title,
                        Genre = movieDto.Genre,
                        Duration = movieDto.Duration,
                        Rating = movieDto.Rating,
                        Director = movieDto.Director
                    };

                    context.Movies.Add(movie);
                    sb.AppendLine($"Successfully imported {movie.Title} with genre {movie.Genre} and rating {movie.Rating:F2}!");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            ValidationContext validator = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationResults, true);

            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            ImportHallAndSeatsDto[] hallDtos = JsonConvert.DeserializeObject<ImportHallAndSeatsDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var hallDto in hallDtos)
            {
                if (IsValid(hallDto))
                {
                    Hall hall = new Hall()
                    {
                        Name = hallDto.Name,
                        Is3D = hallDto.Is3D,
                        Is4Dx = hallDto.Is4Dx
                    };

                    context.Halls.Add(hall);

                    AddSeatsInDatabase(context, hall.Id, hallDto.Seats);

                    if (hall.Is3D)
                    {
                        sb.AppendLine($"Successfully imported {hall.Name}(3D) with {hallDto.Seats} seats!");
                    }
                    else if (hall.Is4Dx)
                    {
                        sb.AppendLine($"Successfully imported {hall.Name}(4Dx) with {hallDto.Seats} seats!");

                    }
                    else if (hall.Is3D && hall.Is4Dx)
                    {
                        sb.AppendLine($"Successfully imported {hall.Name}(4Dx/3D) with {hallDto.Seats} seats!");
                    }
                    else
                    {
                        sb.AppendLine($"Successfully imported {hall.Name}(Normal) with {hallDto.Seats} seats!");
                    }

                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            return sb.ToString().TrimEnd();

        }

        private static void AddSeatsInDatabase(CinemaContext context, int id, int seatsCount)
        {
            List<Seat> seats = new List<Seat>();

            for (int i = 0; i < seatsCount; i++)
            {
                Seat seat = new Seat()
                {
                    HallId = id
                };

                seats.Add(seat);
            }

            context.Seats.AddRange(seats);
            context.SaveChanges();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]),
                new XmlRootAttribute("Projections"));

            ImportProjectionDto[] projectionsDtos;

            using (StringReader reader = new StringReader(xmlString))
            {
                projectionsDtos = (ImportProjectionDto[])xmlSerializer.Deserialize(reader);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var projectionDto in projectionsDtos)
            {
                if (IsValid(projectionDto) 
                    && IsExistsMovieAndHall(projectionDto.MovieId, projectionDto.HallId, context))
                {
                    Projection projection = new Projection()
                    {
                        MovieId = projectionDto.MovieId,
                        HallId = projectionDto.HallId,
                        DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                    };

                    context.Projections.Add(projection);

                    string movieTitle = context.Movies.FirstOrDefault(x => x.Id == projectionDto.MovieId).Title;
                    sb.AppendLine($"Successfully imported projection {movieTitle} on {projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}!");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

        private static bool IsExistsMovieAndHall(int movieId, int hallId, CinemaContext context)
        {
            bool isExistMovie = context.Movies.Any(x => x.Id == movieId);
            bool isExistHall = context.Halls.Any(x => x.Id == hallId);

            return isExistMovie && isExistHall;

        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerTicketDto[]),
                new XmlRootAttribute("Customers"));

            ImportCustomerTicketDto[] customerTicketDtos;

            using (StringReader reader = new StringReader(xmlString))
            {
                customerTicketDtos = (ImportCustomerTicketDto[])xmlSerializer.Deserialize(reader);
            }

            List<Customer> customers = new List<Customer>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in customerTicketDtos)
            {
                if (IsValid(dto))
                {
                    List<Ticket> tickets = new List<Ticket>();
                    foreach (var ticketDto in dto.Tickets)
                    {
                        Ticket ticket = new Ticket()
                        {
                            ProjectionId = ticketDto.ProjectionId,
                            Price = ticketDto.Price
                        };

                        tickets.Add(ticket);
                    }

                    Customer customer = new Customer()
                    {
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        Age = dto.Age,
                        Balance = dto.Balance,
                        Tickets = tickets
                    };

                    customers.Add(customer);
                    sb.AppendLine($"Successfully imported customer {customer.FirstName} {customer.LastName} with bought tickets: {customer.Tickets.Count}!");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
    }
}