using Application.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class FuncionService : IFuncionService
    {
        private readonly IFuncionesCommand _command;
        private readonly IFuncionesQuery _query;

        public FuncionService(IFuncionesCommand command, IFuncionesQuery query)
        {
            _command = command;
            _query = query;
        }

       public async Task  CreateFuncion(Funcion nuevaFuncion)
        {
            _command.InsertFuncion(nuevaFuncion);
        }

        public List<Funcion> GetAllFunciones()
        {
            throw new NotImplementedException();
        }

        public List<Pelicula> GetAllPeliculas()
        {
            throw new NotImplementedException();
        }

        public List<Sala> GetAllSalas()
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionesPorFecha(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionesPorFechaYPelicula(DateTime? fecha, string tituloPelicula)
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionesPorPelicula(int peliculaId)
        {
            throw new NotImplementedException();
        }
    }
}
