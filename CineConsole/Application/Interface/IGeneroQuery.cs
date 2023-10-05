using Domain;

namespace Application.Interface
{
    public interface IGeneroQuery
    {
        public List<Genero> GetListGeneros();
        public Genero GetById(int generoId);

    }
}
