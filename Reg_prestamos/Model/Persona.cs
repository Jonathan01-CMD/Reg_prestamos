using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reg_prestamos.Model
{
    public class Persona
    {
        [Key]
        [Required(ErrorMessage = "El campo PersonasID no puede estar vacio")]
        public int PersonaID { get; set; }

        [Required(ErrorMessage = "El campo Nombres no puede estar vacio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Telefono no puede estar vacio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Cedula no puede estar vacio")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo Direccion no puede estar vacio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Fecha Nacimiento no puede estar vacio")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        public decimal Balance { get; set; } = 0;
    }
}
