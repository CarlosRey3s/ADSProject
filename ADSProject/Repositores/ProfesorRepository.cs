using ADSProject.Db;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositores
{
    
    public class ProfesorRepository : IProfesor
    {
        /*private List<Profesor> lstprofesor = new List<Profesor>
        {
            new Profesor{IdProfesor = 1, NombresProfesor = "JUAN CARLOS",
            ApellidosProfesor= "PEREZ SOSA", Email = "JCPS@gmail.com",

            }
        };*/

        private readonly ApplicationDbContext applicationDbContext;
        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                applicationDbContext.Profesores.Add(profesor);
                applicationDbContext.SaveChanges();
                return profesor.IdProfesor;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);

                applicationDbContext.Entry(item).CurrentValues.SetValues(profesor);
                applicationDbContext.SaveChanges();
                return idProfesor;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);
                applicationDbContext.Profesores.Remove(item);
                applicationDbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Profesor ObtenerprofesorPorID(int idprofesor)
        {

            try
            {
                var profesor = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idprofesor);
                return profesor;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Profesor> ObtenerTodosLosProfesores()
        {
            try
            {
                return applicationDbContext.Profesores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
