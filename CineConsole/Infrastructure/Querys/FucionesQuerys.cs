using Application.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class FucionesQuerys : IFuncionesQuery
    {
        private readonly CineDdContext _context;

        public FucionesQuerys(CineDdContext context)
        {
            _context = context;
        }

        public Funcion GetFuncion(int FuncionId)
        {
            IQueryable<Funcion> query = _context.Funciones;
            var fun = (Funcion)query.FirstOrDefault(x => x.FuncionId == FuncionId);
            if (fun == null)
            {
                throw new InvalidOperationException("No se encontro una Funcion con el Id especificado");
            }
            return fun;
        }

        public List<Funcion> GetListFunciones()
        {
            IQueryable<Funcion> query = _context.Funciones;
            var fun = query.ToList();
            if (fun.Count == 0)
            {
                throw new InvalidOperationException("No se encontraron Funciones Existentes");
            }
            return fun;
        }
    }
}
