using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class FuncionesQuery : IFuncionesQuery
    {
        private readonly CineDdContext _context;

        public FuncionesQuery(CineDdContext context)
        {
            _context = context;
        }

        public List<Funcion> GetListFuncionesByPeliculaId(int peliculaId)
        {
            return _context.Funciones
                .Include(f => f.Peliculas)
                .Include(f => f.Salas)
                .Include(f => f.Tickets)
                .Where(f => f.PeliculaId == peliculaId)
                .ToList();
        }

      
        public List<Funcion> GetListaFunciones()
        {
            return _context.Funciones
                .Include(f => f.Peliculas)
                .Include(f => f.Salas)
                .Include(f => f.Tickets)
                .ToList();
        }

        public Funcion GetFuncionById(int funcionId)
        {
            return _context.Funciones.FirstOrDefault(f => f.FuncionId == funcionId);
        }


        public List<Funcion> GetListaByFecha( DateTime fecha)
        {
            return _context.Funciones
                .Include(f => f.Peliculas)
                .Include(f => f.Salas)
                .Include(f => f.Tickets)
                .Where( f=> f.Fecha == fecha).ToList();
        }

        public List<Funcion> GetListaByTituloAndFecha(string tituloPelicula, DateTime? fecha)
        {


            var query = _context.Funciones
                        .Include(f => f.Peliculas)
                        .Include(f => f.Salas)
                        .Include(f => f.Tickets)
                        .AsQueryable();

            if (fecha.HasValue)
            {
                query = query.Where(f => f.Fecha.Date == fecha.Value.Date);
            }

            if (!string.IsNullOrWhiteSpace(tituloPelicula))
            {
                query = query.Where(f => f.Peliculas.Titulo.Contains(tituloPelicula, StringComparison.OrdinalIgnoreCase));
            }

            return query.ToList();


        }

      
    }
}
