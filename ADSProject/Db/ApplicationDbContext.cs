using ADSProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ADSProject.Db
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Carrera> Carrera { get; set; }
        public DbSet<Grupo> Grupos { get; set; }

        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }


    }
}
