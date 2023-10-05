using Domain;

namespace Application.Interface
{
    public interface IFuncionesCommand
    {
        public void InsertFuncion(Funcion nuevaFuncion);

        public void DeleteFuncion(Funcion funcion);
    }
}
