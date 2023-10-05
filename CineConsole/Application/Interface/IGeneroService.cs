using Domain;

namespace Application.Interface
{
    public interface IGeneroService
    {
        public string GetGeneroNombreById(int peliculaId);

        public List<Genero> GetAllGeneros();

    }
}
