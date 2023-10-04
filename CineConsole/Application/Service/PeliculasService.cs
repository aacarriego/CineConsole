using Application.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class PeliculasService
    {
        private readonly IPeliculasQuery _peliculasQuery;

        public PeliculasService(IPeliculasQuery peliculasQuery)
        {
            _peliculasQuery = peliculasQuery;
        }

        public List<Pelicula> GetAllPeliculas()
        {
            return _context.Peliculas.ToList();
        }

        public string GetPeliculaTituloById(int peliculaId)
        {
            // Utiliza tu DbContext para consultar la base de datos y obtener el título de la película
            var pelicula = _context.Peliculas.FirstOrDefault(p => p.PeliculaId == peliculaId);

            if (pelicula != null)
            {
                return pelicula.Titulo;
            }
            else
            {
                // Manejar el caso en el que el ID de la película no existe
                return "Película no encontrada";
            }
        }


    }
}
