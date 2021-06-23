using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Reg_prestamos.BLL;

namespace Reg_prestamos.Model
{
    public class MorasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int MorasId { get; set; }
        public int PrestamosId { get; set; }
        public decimal Valor { get; set; }
        public string Nombre { get; set; }


    }
}
