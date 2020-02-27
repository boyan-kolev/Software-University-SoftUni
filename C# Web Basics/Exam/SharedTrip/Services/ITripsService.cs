using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void Add(string startPoint, string endPoint, string departureTime, string imagePath, int seats, string description);
        IEnumerable<AllTripViewModel> GetAll();

        TripInfoViewModel GetTripinfo(string id);

        void AddUserToTrip(string tripId, string userId);
    }
}
