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

        public List<Funcion> GetListFuncionesByPeliculaId(int peliculaId)
        {
            return _context.Funciones.Where(f => f.PeliculaId == peliculaId).ToList();
        }

      
        public List<Funcion> GetListaFunciones()
        {
            return _context.Funciones.ToList();
        }

        public Funcion GetFuncionById(int funcionId)
        {
            return _context.Funciones.FirstOrDefault(f => f.FuncionId == funcionId);
        }

        public List<Funcion> GetListaBySalaId(int salaId)
        {
            return _context.Funciones.Where(f => f.SalaId == salaId).ToList();
        }

        public List<Funcion> GetListaByFecha(int salaId, DateTime fecha)
        {
            return _context.Funciones.Where(f => f.SalaId == salaId && f.Fecha == fecha).ToList();
        }

        public List<Funcion> GetListaByTituloAndFecha(string tituloPelicula, DateTime fecha)
        {
            return _context.Funciones.Where(f => f.PeliculaId == peliculaId && f.Fecha == fecha).ToList();
        }


    }
}
