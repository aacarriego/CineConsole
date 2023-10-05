
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using Infrastructure;

namespace PSCineGBA.Controller
{
    public class FuncionService
    {
        private readonly CineDdContext _context;

        public FuncionService(  CineDdContext context)
        
        {
            _context = context;
        }
        public void CreateFuncion(Funcion nuevaFuncion)
        {
            _context.Funciones.Add(nuevaFuncion);
            _context.SaveChanges();
        }

        public List<Funcion> GetAllFunciones()
        {
            return _context.Funciones.ToList();
        }

        public List<Pelicula> GetAllPeliculas()
        {
            return _context.Peliculas.ToList();
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
