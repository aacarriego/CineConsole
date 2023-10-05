using Application.Interface;
using Domain;

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
            throw new NotImplementedException();
        }

        public List<Pelicula> GetListPeliculas()
        {
            return _context.Peliculas.ToList();
        }
    }
}
