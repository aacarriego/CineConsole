using Domain;

namespace Application.Interface
{
    public interface IPeliculasQuery
    {
        List<Pelicula> GetListPeliculas();
        Pelicula GetById(int peliculaId);
    }
}
