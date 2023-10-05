using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IFuncionesQuery
    {
        public List<Funcion> GetListFuncionesByPeliculaId(int peliculaId);

        public List<Funcion> GetListaFunciones();

        public Funcion GetFuncionById(int funcionId);

        public List<Funcion> GetListaBySalaId(int salaId);

        public List<Funcion> GetListaByFecha(int salaId, DateTime fecha);

        public List<Funcion> GetListaByTituloAndFecha(int peliculaId, DateTime fecha);


    }

}
