using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Series
{
    public class FilterSerieViewModel
    {
        public string? SerieSearch { get; set; }
        public int? GenreId { get; set; }
        public int? ProductoraId { get; set; }
    }
}
