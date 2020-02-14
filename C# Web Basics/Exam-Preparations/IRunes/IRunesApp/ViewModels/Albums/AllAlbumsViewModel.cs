using System;
using System.Collections.Generic;
using System.Text;
using IRunesApp.Models;

namespace IRunesApp.ViewModels.Albums
{
    public class AllAlbumsViewModel
    {
        public IEnumerable<AlbumInfoViewModel> Albums { get; set; }
    }
}
