using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Series
{
    public class SerieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Url { get; set; }
        public string PrimaryGenreName { get; set; }
        public int PrimaryGenreId { get; set; }
        public string? SecondaryGenreName { get; set; }
        public int? SecondaryGenreId { get; set; }
        public string? ProductoraName { get; set; }
        public int ProductoraId { get; set; }
    }
}
