using ADSProject.Db;
using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositores
{
    public class CarreraRepository : IECarrera
    {
        
        private readonly ApplicationDbContext applicationDbContext;
        public CarreraRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int AgregarCarrera(Carrera carrera)
        {
            try
            {

                applicationDbContext.Carrera.Add(carrera);
                applicationDbContext.SaveChanges();
                return carrera.IdCarrera;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public int ActualizarCarrera(int idCarrera, Carrera carrera)
        {
            try
            {
                var item = applicationDbContext.Carrera.SingleOrDefault(x => x.IdCarrera == idCarrera);

                applicationDbContext.Entry(item).CurrentValues.SetValues(carrera);
                applicationDbContext.SaveChanges();
                return idCarrera;

            }
            catch (Exception ex)
            {
                throw;
            }
        } 
        public bool EliminarCarrera(int idCarrera)
        {
            try
            {
                var item = applicationDbContext.Carrera.SingleOrDefault(x => x.IdCarrera == idCarrera);
                applicationDbContext.Carrera.Remove(item);
                applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Carrera ObtenercarrerasPorID(int idcarreras)
        {
            try
            { 
                 var carrera = applicationDbContext.Carrera.SingleOrDefault(x => x.IdCarrera == idcarreras);
                 return carrera;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Carrera> ObtenerTodosLasCarreras()
        {
            try
            {
                return applicationDbContext.Carrera.ToList();   
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
