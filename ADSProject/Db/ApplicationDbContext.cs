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
    }
}
