using Application.Interface;
using Domain;

namespace Infrastructure.Query
{
    public class SalasQuery : ISalasQuery
    {
        private readonly CineDdContext _context;

        public SalasQuery(CineDdContext context)
        {
            _context = context;
        }

        public Sala GetById(int salaId)
        {
            return _context.Salas.FirstOrDefault(x => x.SalaId == salaId);
        }

        public List<Sala> GetListSalas()
        {
          return _context.Salas.ToList();
        }
    }
}
