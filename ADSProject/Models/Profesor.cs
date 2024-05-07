using ADSProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    [PrimaryKey(nameof(IdProfesor))]
    public class Profesor
    {
        public int IdProfesor { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud de este campo no puede ser mayor a 50 caracteres.")]
        public string NombresProfesor { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud de este campo no puede ser mayor a 50 caracteres.")]
        public string ApellidosProfesor { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        [MaxLength(length: 254, ErrorMessage = "La longitud de este campo no puede ser mayor a 254 caracteres.")]
        public string Email {  get; set; }
    }
}
