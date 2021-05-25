using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reg_prestamos.Model
{
    public class RegPersona
    {
        [Key]
        [Required(ErrorMessage = "Campo PrestamoID no debe estar vacio")]
        public int PrestamoID { get; set; }

        [Required(ErrorMessage ="No puede dejar el campo fecha vacio")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DataType Fecha { get; set; }

        [Required(ErrorMessage = "No puede dejar el campo PersonasID vacio")]
        public int PersonasID {get; set;}

        [Required(ErrorMessage = "No puede dejar el campo Concepto vacio")]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "No puede dejar el campo Monton vacio")]
        public float Monto { get; set; }

        public float Balance { get; set; }
    }
}
