using IRunesApp.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesApp.Services
{
    public interface ITracksService
    {
        void Create(string name, string link, decimal price, string AlbumId);

        TrackInfoViewModel GetInfo(string albumId, string trackId);
    }
}
