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
        public double Total { get; set; }

        [ForeignKey("MorasId")]
        public List<MorasDetalle> Detalle { get; set; }

        public Moras()
        {
            MorasId = 0;
            Fecha = DateTime.Now;
            Total = 0;
        }

    }
}
