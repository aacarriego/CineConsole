using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IFuncionService
    {
        void CreateFuncion(Funcion nuevaFuncion);

        List<Funcion> GetAllFunciones();

        List<Funcion> GetFuncionesPorFechaYPelicula(DateTime? fecha, string tituloPelicula);

        List<Funcion> GetFuncionesPorFecha(DateTime fecha);

        List<Funcion> GetFuncionesPorPelicula(int peliculaId);
    }
}
