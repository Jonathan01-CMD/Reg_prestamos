using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reg_prestamos.Model
{
    public class Moras
    {
        [Key]
        public int MorasId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("MorasId")]
        public List<MorasDetalle> Detalle { get; set; } = new List<MorasDetalle>();

        public Moras()
        {
            MorasId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            Detalle = new List<MorasDetalle>();
        }

    }
}
