﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Funcion
    {
        // PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FuncionId { get; set; }

        /// FK1
        public int PeliculaId { get; set; }

        /// FK2
        public int SalaId { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime Horario { get; set; }

        public virtual Pelicula Peliculas { get; set; }

        public virtual Sala Salas { set; get; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
