using IRunesApp.ViewModels.Albums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesApp.Services
{
    public interface IAlbumsService
    {
        void Create(string name, string cover);

        IEnumerable<AlbumInfoViewModel> GetAll();

        AlbumDetailsViewModel GetDetails(string id);
    }
}
