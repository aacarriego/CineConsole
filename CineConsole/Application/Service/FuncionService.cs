using Application.Interface;
using Domain;

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
            return _context.Funciones.ToList();
        }

        public List<Funcion> GetFuncionesPorFechaYPelicula(DateTime? fecha, string tituloPelicula)
        {
            IQueryable<Funcion> query = _context.Funciones.Include(f => f.Peliculas).Include(f => f.Salas);

            if (fecha.HasValue)
            {
                query = query.Where(f => f.Fecha.Date == fecha.Value.Date);
            }

            if (!string.IsNullOrEmpty(tituloPelicula))
            {
                query = query.Where(f => f.Peliculas.Titulo.Contains(tituloPelicula));
            }

            return query.ToList();
        }

        public List<Funcion> GetFuncionesPorFecha(DateTime fecha)
        {
            IQueryable<Funcion> query = _context.Funciones.Include(f => f.Peliculas)
                                                          .Include(f => f.Salas);

            query = query.Where(f => f.Fecha.Date == fecha.Date);

            return query.ToList();
        }

        public List<Funcion> GetFuncionesPorPelicula(int peliculaId)
        {
            IQueryable<Funcion> query = _context.Funciones.Include(f => f.Peliculas).Include(f => f.Salas);

            query = query.Where(f => f.PeliculaId == peliculaId);

            return query.ToList();
        }

    }
}
