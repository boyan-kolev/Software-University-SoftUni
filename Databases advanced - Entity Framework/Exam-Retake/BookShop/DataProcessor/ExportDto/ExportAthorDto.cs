using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DataProcessor.ExportDto
{
    public class ExportAthorDto
    {
        public string AuthorName { get; set; }

        public ICollection<ExportAuthorbookDto> Books { get; set; }
    }
}
