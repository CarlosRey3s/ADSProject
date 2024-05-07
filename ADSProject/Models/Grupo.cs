using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    [PrimaryKey(nameof(IdGrupo))]
    public class Grupo
    {
        public int IdGrupo { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        public int IdCarrera { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        public int IdProfesor {  get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        public int Ciclo { get; set; }
        [Required(ErrorMessage = "Este es un camo requerido")]
        public int Anio { get; set; }
    }
}
