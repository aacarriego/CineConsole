using Domain;

namespace Application.Interface
{
    public interface IFuncionService
    {
        void CreateFuncion(Funcion nuevaFuncion);

        List<Funcion> GetAllFunciones();

        List<Funcion> GetFuncionesPorFechaYPelicula(DateTime? fecha, string tituloPelicula);

        List<Funcion> GetFuncionesPorFecha(DateTime fecha);

        List<Funcion> GetFuncionesPorPelicula(int peliculaId);
    }
}
