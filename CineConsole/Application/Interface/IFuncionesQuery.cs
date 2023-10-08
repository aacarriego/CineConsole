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

        public List<Funcion> GetListaByFecha( DateTime fecha);

        public List<Funcion> GetListaByTituloAndFecha(string tituloPelicula, DateTime? fecha);


    }

}
