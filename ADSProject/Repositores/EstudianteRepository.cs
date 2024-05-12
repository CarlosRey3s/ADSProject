using ADSProject.Db;
using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositores

{
    public class EstudianteRepository : IEstudiante
    {
       /* private List<Estudiante> lstEstudiante = new List<Estudiante>
        {
            new Estudiante{IdEstudiante = 1, NombreEstudiante = "JUAN CARLOS",
            ApellidoEstudiante= "PEREZ SOSA", Codigoestudiante = "PS24I04002",
            Correoestudiante = "PS24I04002@usonsonate.edu.sv"
            }
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public EstudianteRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int AgregarEstudiante(Estudiante estudiante)
        {
            try
            {
               /* if (lstEstudiante.Count > 0)
                {
                    estudiante.IdEstudiante = lstEstudiante.Last().IdEstudiante + 1;
                }
                lstEstudiante.Add(estudiante);
                */
               applicationDbContext.Estudiantes.Add(estudiante);
               applicationDbContext.SaveChanges();

                return estudiante.IdEstudiante;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {
            try
            {/*
                int indice = lstEstudiante.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                lstEstudiante[indice] = estudiante;
                return idEstudiante;*/

                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);

                applicationDbContext.Entry(item).CurrentValues.SetValues(estudiante);

                applicationDbContext.SaveChanges();

                return idEstudiante;
            }
            catch (Exception ex)
            {
                throw;
            }
            return 0;
        }
        public bool EliminarEstudiante(int idEstudiante)
        {
             try
             {
                /*int indice = lstEstudiante.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                lstEstudiante.RemoveAt(indice);
                return true;*/
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);

                applicationDbContext.Estudiantes.Remove(item);

                applicationDbContext.SaveChanges();

                return true;
             }
             catch (Exception ex)
             {
                 throw;
             }
            
        }
        public Estudiante ObtenerEstudiantesPorID(int idEstudiante)
        {
           var estudiante = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante==idEstudiante);

            return estudiante;
        }
        public List<Estudiante> ObtenerTodosLosEstudinates()
        {
            try
            {
                return applicationDbContext.Estudiantes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
