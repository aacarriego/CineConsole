using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IGeneroService
    {
        public string GetGeneroNombreById(int peliculaId);

        public List<Genero> GetAllGeneros();

    }
}
