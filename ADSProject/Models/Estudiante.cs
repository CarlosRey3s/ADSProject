using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    [PrimaryKey (nameof(IdEstudiante))]
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud de este campo no puede ser mayor a 50 caracteres.")]

        public string NombreEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud de este campo no puede ser mayor a 50 caracteres.")]

        public string ApellidoEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        [MinLength(length: 12, ErrorMessage = "La longitud de este campo no puede ser mayor a 12 caracteres.")]
        [MaxLength(length: 50, ErrorMessage = "La longitud de este campo no puede ser mayor a 50 caracteres.")]

        public string Codigoestudiante { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        [MaxLength(length: 254, ErrorMessage = "La longitud de este campo no puede ser mayor a 254 caracteres.")]
        [EmailAddress(ErrorMessage = "El formato de correro electronico no es valido.")]

        public string Correoestudiante { get; set; }
    }
}
