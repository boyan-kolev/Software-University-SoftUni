using IRunesApp.Services;
using IRunesApp.ViewModels.Tracks;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesApp.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        public HttpResponse Create(TrackAlbumIdViewmodel model)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }

            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(TrackInputModel input)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect($"/Tracks/Create?albumId={input.AlbumId}");
            }

            if (string.IsNullOrWhiteSpace(input.Link) || input.Price <= 0.0M)
            {
                return this.Redirect($"/Tracks/Create?albumId={input.AlbumId}");
            }

            if (input.Link.StartsWith("http") == false)
            {
                return this.Redirect($"/Tracks/Create?albumId={input.AlbumId}");
            }

            this.tracksService.Create(input.Name, input.Link, input.Price, input.AlbumId);

            return this.Redirect($"/Albums/Details?id={input.AlbumId}");

        }

        public HttpResponse Details(TrackInfoInputModel input)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }

            var trackInfo = this.tracksService.GetInfo(input.AlbumId, input.TrackId);

            return this.View(trackInfo);
        }
    }
}
