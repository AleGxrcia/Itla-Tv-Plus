using Application.ViewModels.Generos;
using Application.ViewModels.Productora;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Series
{
    public class SaveSerieViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Url de Imagen")]
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Url de Video")]
        public string Url { get; set; }
        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "Genero Primario")]
        [Range(1, int.MaxValue, ErrorMessage = "El {0} es requerido")]
        public int PrimaryGenre { get; set; }
        [Display(Name = "Genero Secundario")]
        public int? SecondaryGenre { get; set; }
        public List<GeneroViewModel>? Generos { get; set; }
        [Required(ErrorMessage = "La {0} es requerida")]
        [Display(Name = "Productora")]
        [Range(1, int.MaxValue, ErrorMessage = "La {0} es requerida")]
        public int ProductoraId { get; set; }
        public List<ProductoraViewModel>? Productoras { get; set; }
    }
}
