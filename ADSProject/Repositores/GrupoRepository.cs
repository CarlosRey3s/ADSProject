using ADSProject.Db;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositores
{
    public class GrupoRepository : IGrupo
    {
        /* private List<Grupo> lstGrupo = new List<Grupo>
         {
             new Grupo{ IdGrupo= 1, IdCarrera = 1, IdMateria = 1,
                 IdProfesor = 1, Ciclo = 01, Anio = 2024,
             }
         };*/

        private readonly ApplicationDbContext applicationDbContext;
        public GrupoRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int AgregarGrupo(Grupo grupo)
        {
            try
            {
               /* if (lstGrupo.Count > 0)
                {
                    grupo.IdProfesor = lstGrupo.Last().IdGrupo + 1;
                }
                lstGrupo.Add(grupo);*/

                applicationDbContext.Grupos.Add(grupo);
                applicationDbContext.SaveChanges();
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
                /*  int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);
                  lstGrupo[indice] = grupo;
                  return idGrupo;*/

                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGrupo);
                
                applicationDbContext.Entry(item).CurrentValues.SetValues(idGrupo);
                applicationDbContext.SaveChanges();
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
                /*int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);
                lstGrupo.RemoveAt(indice);
                return true;*/

                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGrupo);
                applicationDbContext.Grupos.Remove(item);
                applicationDbContext.SaveChanges();
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
                var grupo = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGgrupo);
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
                return applicationDbContext.Grupos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
