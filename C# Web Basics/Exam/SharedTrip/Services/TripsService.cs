using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(string startPoint, string endPoint, string departureTime, string imagePath, int seats, string description)
        {
            Trip trip = new Trip()
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = DateTime.ParseExact(departureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = imagePath,
                Seats = seats,
                Description = description
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            UserTrip userTrip = new UserTrip()
            {
                TripId = tripId,
                UserId = userId
            };

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
        }

        public IEnumerable<AllTripViewModel> GetAll()
        {
            IEnumerable<AllTripViewModel> trips = this.db.Trips
                .Select(x => new AllTripViewModel()
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    Seats = x.Seats
                })
                .ToArray();

            return trips;
        }

        public TripInfoViewModel GetTripinfo(string id)
        {
            TripInfoViewModel tripinfo = this.db.Trips
                .Where(x => x.Id == id)
                .Select(x => new TripInfoViewModel()
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Seats = x.Seats,
                    Description = x.Description,
                    ImagePath = x.ImagePath
                })
                .FirstOrDefault();

            return tripinfo;
        }
    }
}
