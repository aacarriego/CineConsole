using Application.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class PeliculaQuery : IPeliculasQuery
    {
        private readonly CineDdContext _context;

        public PeliculaQuery(CineDdContext context)
        {
            _context = context;
        }
        public Pelicula GetById(int peliculaId)
        {
            return _context.Peliculas.FirstOrDefault(p => p.PeliculaId == peliculaId);
        }

        public List<Pelicula> GetListPeliculas()
        {
          return _context.Peliculas.ToList();
        }
    }
}
