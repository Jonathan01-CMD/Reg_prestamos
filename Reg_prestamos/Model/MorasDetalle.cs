using Reg_prestamos.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reg_prestamos.Model
{
    public class MorasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int MorasId { get; set; }
        public int PrestamosId { get; set; }
        public string MorasName { get; set; }
        public decimal Valor { get; set; }


    }
}
