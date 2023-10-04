using Application.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class FuncionesCommand : IFuncionesCommand
    {
        private readonly CineDdContext _context;

        public FuncionesCommand(CineDdContext context)
        {
            _context = context;
        }

        public void InsertFuncion(Funcion nuevaFuncion)
        {
            _context.Funciones.Add(nuevaFuncion);
            _context.SaveChanges();
        }

        public void DeleteFuncion(Funcion funcion)
        {
            throw new NotImplementedException();
        }

      
    }
}
