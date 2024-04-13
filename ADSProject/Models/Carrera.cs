using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Carrera
    {
        public int IdCarrera { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        [MaxLength(length: 3, ErrorMessage = "La longitud de este campo no puede ser mayor a 3 caracteres.")]

        public string CodigoCarrera { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        [MaxLength(length: 40, ErrorMessage = "La longitud de este campo no puede ser mayor a 40 caracteres.")]

        public string NombreCarrera { get; set; }

    }
}
