using Application.Interface;
using Domain;

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
