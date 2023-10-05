using Application.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroQuery _generoQuery;

        public GeneroService(IGeneroQuery generoQuery)
        {
            _generoQuery = generoQuery;
        }

        public string  GetGeneroNombreById(int peliculaId)
        {
           
            var genero = _generoQuery.GetById(peliculaId);
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

        List<Genero> IGeneroService.GetAllGeneros()
        {
            return _generoQuery.GetListGeneros();
        }
    }

}
