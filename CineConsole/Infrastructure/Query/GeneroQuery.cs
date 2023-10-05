using Application.Interface;
using Domain;


namespace Infrastructure.Query
{
    public class GeneroQuery : IGeneroQuery
    {
        private readonly CineDdContext _context;

        public GeneroQuery(CineDdContext context)
        {
            _context = context;
        }

        public List<Genero> GetListGeneros()
        {
            return _context.Generos.ToList();
        }

        public Genero GetById(int generoId)
        {
            return _context.Generos.FirstOrDefault(g => g.GeneroId == generoId);
        }
    }
}
