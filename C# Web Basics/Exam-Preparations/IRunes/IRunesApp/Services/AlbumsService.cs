using IRunesApp.Models;
using IRunesApp.ViewModels.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunesApp.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AlbumInfoViewModel> GetAll()
        {
            IEnumerable<AlbumInfoViewModel> albums = this.db.Albums
                .Select(x => new AlbumInfoViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            return albums;

        }

        public void Create(string name, string cover)
        {
            Album album = new Album()
            {
                Name = name,
                Cover = cover,
                Price = 0.0M
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public AlbumDetailsViewModel GetDetails(string id)
        {
            AlbumDetailsViewModel albumDetail = this.db.Albums
                .Where(x => x.Id == id)
                .Select(x => new AlbumDetailsViewModel
                {
                    Id = x.Id,
                    Cover = x.Cover,
                    Name = x.Name,
                    Price = x.Price,
                    Tracks = x.Tracks.Select(t => new AlbumTracksViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                    .ToList()
                })
                .FirstOrDefault();

            return albumDetail;
        }
    }
}
