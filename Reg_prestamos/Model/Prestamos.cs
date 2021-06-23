using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reg_prestamos.Model
{
    public class Prestamos
    {
        [Key]
        [Required(ErrorMessage = "No debe de estar Vacío este campo")]
        public int PrestamoID { get; set; }

        [Required(ErrorMessage = "No puede dejar el campo fecha vacio")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "No puede dejar el campo PersonasID vacio")]
        public int PersonasID { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío este campo")]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "No puede dejar el campo Monton vacio")]
        public decimal Monto { get; set; }

        public decimal Balance { get; set; }

        public Prestamos()
        {
            PrestamoID = 0;
            PersonasID = 0;
            Concepto = "";
            Monto = 0;
            Balance = 0;
        }

    }
}
