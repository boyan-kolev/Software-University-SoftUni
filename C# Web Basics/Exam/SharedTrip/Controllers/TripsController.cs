using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("Users/Login");
            }

            var viewModel = this.tripsService.GetAll();

            return this.View(viewModel);
        }

        public HttpResponse Add()
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripInputModel input)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("Users/Login");
            }

            if (string.IsNullOrEmpty(input.StartPoint) || string.IsNullOrEmpty(input.StartPoint))
            {
                return this.Redirect("/Trips/Add");
            }

            if (string.IsNullOrEmpty(input.EndPoint) || string.IsNullOrEmpty(input.EndPoint))
            {
                return this.Redirect("/Trips/Add");
            }

            if (string.IsNullOrEmpty(input.DepartureTime) || string.IsNullOrEmpty(input.DepartureTime))
            {
                return this.Redirect("/Trips/Add");
            }

            if (string.IsNullOrEmpty(input.Description) || string.IsNullOrEmpty(input.Description))
            {
                return this.Redirect("/Trips/Add");
            }

            if (DateTime.TryParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime) == false)
            {
                return this.Redirect("/Trips/Add");
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.Redirect("/Trips/Add");
            }

            if (input.Description.Length > 80)
            {
                return this.Redirect("/Trips/Add");
            }

            this.tripsService.Add(input.StartPoint, input.EndPoint, input.DepartureTime, input.ImagePath, input.Seats, input.Description);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("Users/Login");
            }

            var viewModel = this.tripsService.GetTripinfo(tripId);

            return this.View(viewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("Users/Login");
            }

            this.tripsService.AddUserToTrip(tripId, this.User);

            return this.Redirect("/Trips/All");
        }
    }
}
