using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryServicesWeb_AP2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryServicesWeb_AP2.Models;

namespace LibraryServicesWeb_AP2.BLL.Tests
{
    [TestClass()]
    public class DevolucionesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Devoluciones devoluciones = new Devoluciones();
            devoluciones.DevolucionId = 1;
            devoluciones.FechaDevueltaLibro = DateTime.Now;

            paso = DevolucionesBLL.Guardar(devoluciones);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Devoluciones devoluciones = new Devoluciones();
            devoluciones.DevolucionId = 1;
            devoluciones.FechaDevueltaLibro = DateTime.Now;


            paso = DevolucionesBLL.Modificar(devoluciones);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var paso = DevolucionesBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = DevolucionesBLL.Buscar(1);
            Assert.IsNotNull(paso);
        }


        [TestMethod()]
        public void GetListTest()
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            lista = DevolucionesBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = DevolucionesBLL.Existe(1);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetDevolucionesTest()
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            lista = DevolucionesBLL.GetDevoluciones();
            Assert.IsNotNull(lista);
        }
    }
}