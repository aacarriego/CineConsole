using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class GeneroService : IGeneroService
    {
        public string GetGeneroNombreById(int peliculaId)
        {
            /*  Recibe un generoId como parámetro y busca en la base de datos 
             *  el género correspondiente al ID proporcionado. 
             *  Si encuentra el género, devuelve su nombre; de lo contrario
             *  , devuelve un mensaje indicando que el género no se encontró. */
            var genero = _context.Generos.FirstOrDefault(g => g.GeneroId == peliculaId);
            if (genero != null)

            {
                return genero.Nombre;
            }
            else
            {
                // Manejar el caso en el que el ID de la sala no existe
                return "¿Genero NULL?";
            }

        }
    }
}
