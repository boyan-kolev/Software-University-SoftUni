using IRunesApp.Services;
using IRunesApp.ViewModels.Album;
using IRunesApp.ViewModels.Albums;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesApp.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        public HttpResponse All()
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }

            AllAlbumsViewModel allAlbums = new AllAlbumsViewModel()
            {
                Albums = this.albumsService.GetAll()
            };


            return this.View(allAlbums);
        }


        public HttpResponse Create()
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(AlbumInputModel input)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                this.Redirect("/Albums/Create");
            }

            if (string.IsNullOrWhiteSpace(input.Cover))
            {
                this.Redirect("/Albums/Create");
            }

            this.albumsService.Create(input.Name, input.Cover);

            return this.Redirect("/Albums/All");
        }

        public HttpResponse Details(string id)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }

            AlbumDetailsViewModel model = this.albumsService.GetDetails(id);

            return this.View(model);
        }
    }
}
