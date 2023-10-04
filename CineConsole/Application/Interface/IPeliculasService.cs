using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPeliculasService
    {
        public string GetPeliculaTituloById(int peliculaId);
        public List<Pelicula> GetAllPeliculas();
    }
}
