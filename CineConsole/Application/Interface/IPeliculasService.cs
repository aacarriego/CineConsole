using Domain;

namespace Application.Interface
{
    public interface IPeliculasService
    {
        public string GetPeliculaTituloById(int peliculaId);
        public List<Pelicula> GetAllPeliculas();
    }
}
