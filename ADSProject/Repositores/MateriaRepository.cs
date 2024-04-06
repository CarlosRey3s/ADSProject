using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositores
{
    public class MateriaRepository : IMateria
    {
        private List<Materia> lstMateria = new List<Materia>
        {
            new Materia{IdMateria = 1, NonmbreMateria = "Desarrollo",
            
            }
        };
        public int AgregarMateria(Materia materia)
        {
            try
            {
                if (lstMateria.Count > 0)
                {
                    materia.IdMateria = lstMateria.Last().IdMateria + 1;
                }
                lstMateria.Add(materia);
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
                int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == idMateria);
                lstMateria[indice] = materia;
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
                int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == idMateria);
                lstMateria.RemoveAt(indice);
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
                Materia materia = lstMateria.FirstOrDefault(tmp => tmp.IdMateria == idMateria);
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
                return lstMateria;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
