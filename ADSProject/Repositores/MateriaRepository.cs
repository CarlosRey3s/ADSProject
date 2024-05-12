using ADSProject.Db;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositores
{
    public class MateriaRepository : IMateria
    {
        /* private List<Materia> lstMateria = new List<Materia>
         {
             new Materia{IdMateria = 1, NonmbreMateria = "Desarrollo",

             }
         };*/
        private readonly ApplicationDbContext applicationDbContext;
        public MateriaRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int AgregarMateria(Materia materia)
        {
            try
            {
               
               applicationDbContext.Materias.Add(materia);
                applicationDbContext.SaveChanges();
                return materia.IdMateria;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int ActualizarMateria(int idMateria, Materia materia)
        {
            try
            {
               var item = applicationDbContext.Materias.FirstOrDefault(x => x.IdMateria == idMateria);

                applicationDbContext.Entry(item).CurrentValues.SetValues(materia);
                applicationDbContext.SaveChanges();
                return idMateria;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        

        public bool EliminarMateria(int idMateria)
        {
            try
            {
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria == idMateria);
                applicationDbContext.Materias.Remove(item);
                applicationDbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Materia ObtenermateriaPorID(int idMateria)
        {
            try
            {
                var materia = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria == idMateria);
                return materia;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Materia> ObtenerTodosLasMaterias()
        {
            try
            {
                return applicationDbContext.Materias.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
