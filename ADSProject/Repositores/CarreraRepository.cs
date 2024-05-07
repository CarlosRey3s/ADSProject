using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositores
{
    public class CarreraRepository : IECarrera
    {
        private List<Carrera> lstCarrera = new List<Carrera>
        {
            new Carrera{IdCarrera = 1, 
            NombreCarrera= "ANALISIS DE SISTEMAS"
            }
        };
        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                if (lstCarrera.Count > 0)
                {
                    carrera.IdCarrera = lstCarrera.Last().IdCarrera + 1;
                }
                lstCarrera.Add(carrera);
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
                int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == idCarrera);
                lstCarrera[indice] = carrera;
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
                int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == idCarrera);
                lstCarrera.RemoveAt(indice);
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
                Carrera carrera = lstCarrera.FirstOrDefault(tmp => tmp.IdCarrera == idcarreras);
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
                return lstCarrera;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
