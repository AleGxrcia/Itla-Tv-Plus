using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Generos
{
    public class SaveGeneroViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}
