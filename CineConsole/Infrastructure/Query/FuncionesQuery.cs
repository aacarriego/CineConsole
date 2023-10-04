using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Domain;

namespace Infrastructure.Query
{
    public class FuncionesQuery : IFuncionesQuery
    {
        private readonly CineDdContext _context;

        public FuncionesQuery(CineDdContext context)
        {
            _context = context;
        }

        public List<Funcion> GetFuncionesByPeliculaId(int peliculaId)
        {
            return _context.Funciones.Where(f => f.PeliculaId == peliculaId).ToList();
        }

    }
}
