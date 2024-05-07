using ADSProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    [PrimaryKey(nameof(IdMateria))]
    public class Materia
    {
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud de este campo no puede ser mayor a 50 caracteres.")]
        public string NonmbreMateria { get; set; }
  
    }
}
