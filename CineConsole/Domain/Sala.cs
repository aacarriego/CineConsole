using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Sala
    {
        // PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaId { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public int Capacidad { get; set; }

        //FUNCNIONES DE LA SALA
        public ICollection<Funcion> Funciones { get; set; }
    }
}
