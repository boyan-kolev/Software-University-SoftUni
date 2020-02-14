using IRunesApp.Models;
using IRunesApp.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunesApp.Services
{
    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext db;

        public TracksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string link, decimal price, string albumId)
        {
            Track track = new Track()
            {
                Name = name,
                Link = link,
                Price = price,
                AlbumId = albumId
            };

            this.db.Tracks.Add(track);

            decimal albumPrice = this.db.Albums.Where(x => x.Id == albumId)
                .Select(x => x.Tracks.Sum(s => s.Price)).FirstOrDefault();

            Album album = this.db.Albums.FirstOrDefault(x => x.Id == albumId);
            album.Price = albumPrice - (albumPrice * 0.13M);

            this.db.SaveChanges();
        }

        public TrackInfoViewModel GetInfo(string albumId, string trackId)
        {
            TrackInfoViewModel trackInfo = this.db.Tracks
                .Where(x => x.Id == trackId && x.AlbumId == albumId)
                .Select(x => new TrackInfoViewModel()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Link = x.Link,
                    Id = x.AlbumId
                })
                .FirstOrDefault();

            return trackInfo;
        }
    }
}
