using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositores
{
    public class GrupoRepository : IGrupo
    {
        private List<Grupo> lstGrupo = new List<Grupo>
        {
            new Grupo{ IdGrupo= 1, IdCarrera = 1, IdMateria = 1,
                IdProfesor = 1, Ciclo = 01, Anio = 2024,

            }
        };
        public int AgregarGrupo(Grupo grupo)
        {
            try
            {
                if (lstGrupo.Count > 0)
                {
                    grupo.IdProfesor = lstGrupo.Last().IdGrupo + 1;
                }
                lstGrupo.Add(grupo);
                return grupo.IdGrupo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int ActualizarGrupo(int idGrupo, Grupo grupo)
        {
            try
            {
                int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);
                lstGrupo[indice] = grupo;
                return idGrupo;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool EliminarGrupo(int idGrupo)
        {
            try
            {
                int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);
                lstGrupo.RemoveAt(indice);
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Grupo ObtenergrupoPorID(int idGgrupo)
        {
            try
            {
                Grupo grupo = lstGrupo.FirstOrDefault(tmp => tmp.IdGrupo == idGgrupo);
                return grupo;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Grupo> ObtenerTodosLosGrupos()
        {
            try
            {
                return lstGrupo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
