using Application.DTO;
using Application.Interface;
using Domain;
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

        public async Task<FuncionResponseDTO> InsertFuncion(Funcion fun)
        {
            _context.Add(fun);
            _context.SaveChanges();
            return new FuncionResponseDTO(); 
        }
        public async Task<FuncionResponseDTO> RemoveFuncion(int funId)
        {
            var funcion = await _context.Funciones.FindAsync(funId);
            if (funcion != null)
            {
                _context.Funciones.Remove(funcion);
                _context.SaveChanges();
                Console.WriteLine("Funcion eliminada correctamente");
            }
            else { Console.WriteLine("No se encontro ninguna Funcion con el Id especificado para eliminar"); }

            return new FuncionResponseDTO();

        }
    }
}
