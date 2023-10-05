using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IGeneroQuery
    {
        public List<Genero> GetListGeneros();
        public Genero GetById(int generoId);

    }
}
