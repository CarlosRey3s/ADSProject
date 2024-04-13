using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Materia
    {
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud de este campo no puede ser mayor a 50 caracteres.")]
        public string NonmbreMateria { get; set; }
  
    }
}
