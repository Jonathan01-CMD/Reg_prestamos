using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reg_prestamos.BLL;
using Reg_prestamos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reg_prestamos.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        private Persona Persona = new Persona()
        {
            PersonaID = 1,
            Nombre = "058000000",
            Direccion = "058000000",
            Cedula = "058000000",
            Fecha = DateTime.Now,
            Telefono = "058000000",
            Balance = 0
        };

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void insertarTest()
        {
            Assert.Fail();

        }

        [TestMethod()]
        public void ExisteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarTest()
        {
            var paso = PersonasBLL.Guardar(Persona);
            Assert.IsTrue(paso, "Error al guardar");
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPersonasTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}