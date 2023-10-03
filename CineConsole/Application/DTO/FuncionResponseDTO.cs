using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class FuncionResponseDTO
    {
       
        public string TituloPelicula { get; set; }
        public string NombreSala { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int PeliculaId { get; set; }
    }
}
