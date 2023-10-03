using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IFuncionesCommand
    {
         Task<FuncionResponseDTO> InsertFuncion(Funcion fun);


         Task<FuncionResponseDTO> RemoveFuncion(int funId);
       
    }
}
