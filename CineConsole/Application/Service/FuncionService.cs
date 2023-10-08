using Application.Interface;
using Domain;
using System.ComponentModel;

namespace Application.Service
{
    public class FuncionService
    {
        private readonly IFuncionesQuery _funcionesQuery;
        private readonly IFuncionesCommand _funcionesCommand;

       
public FuncionService(IFuncionesQuery funcionesQuery, IFuncionesCommand funcionesCommand)
        {
            _funcionesQuery = funcionesQuery;
            _funcionesCommand = funcionesCommand;
        }

        public void CreateFuncion(Funcion nuevaFuncion)
        {
            _funcionesCommand.InsertFuncion(nuevaFuncion);

        }

        public List<Funcion> GetAllFunciones()
        {
            return _funcionesQuery.GetListaFunciones();
        }      

        public List<Funcion> GetFuncionesPorFechaYPelicula(DateTime? fecha, string tituloPelicula)
        {
            return _funcionesQuery.GetListaByTituloAndFecha(tituloPelicula, fecha);
        }

        public List<Funcion> GetFuncionesPorFecha(DateTime fecha)
        {
           return _funcionesQuery.GetListaByFecha(fecha);
        }

        public List<Funcion> GetFuncionesPorPelicula(int peliculaId)
        {
            return _funcionesQuery.GetListFuncionesByPeliculaId(peliculaId);
 
        }

    }
}
