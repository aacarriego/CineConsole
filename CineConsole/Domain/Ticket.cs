using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Ticket
    {
        // PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TicketId { get; set; }
        // FK
        public int FuncionId { get; set; }

        [StringLength(50)]
        public string Usuario { get; set; }

        //FUNCION ASOCIADA AL TKT
        public virtual Funcion funcion { get; set; }
    }
}
