using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositores
{
    
    public class ProfesorRepository : IProfesor
    {
        private List<Profesor> lstprofesor = new List<Profesor>
        {
            new Profesor{IdProfesor = 1, NombresProfesor = "JUAN CARLOS",
            ApellidosProfesor= "PEREZ SOSA", Email = "JCPS@gmail.com",

            }
        };
        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                if (lstprofesor.Count > 0)
                {
                    profesor.IdProfesor = lstprofesor.Last().IdProfesor + 1;
                }
                lstprofesor.Add(profesor);
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
                int indice = lstprofesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                lstprofesor[indice] = profesor;
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
                int indice = lstprofesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                lstprofesor.RemoveAt(indice);
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
                Profesor profesor = lstprofesor.FirstOrDefault(tmp => tmp.IdProfesor == idprofesor);
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
                return lstprofesor;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
