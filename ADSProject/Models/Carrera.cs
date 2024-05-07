using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    [PrimaryKey(nameof(IdCarrera))]

    public class Carrera
    {
        public int IdCarrera { get; set; }
        

        public string NombreCarrera { get; set; }

    }
}
