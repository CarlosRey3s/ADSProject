using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IECarrera
    {
        public int AgregarCarrera(Carrera carrera);

        public int ActualizarCarrera(int idCarrera, Carrera carrera);

        public bool EliminarCarrera(int idCarrera);

        public List<Carrera> ObtenerTodosLasCarreras();

        public Carrera ObtenercarrerasPorID(int carreras);
    }
}

