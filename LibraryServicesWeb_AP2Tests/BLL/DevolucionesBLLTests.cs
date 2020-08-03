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

            DevolucionDetalles devolucionDetalles = new DevolucionDetalles(1, 1, 1, 1, "Oidsea", DateTime.Now);
            List<DevolucionDetalles> list = new List<DevolucionDetalles>();

            list.Add(devolucionDetalles);
            Devoluciones devoluciones = new Devoluciones();
            devoluciones.DevolucionId = 10;
            devoluciones.FechaDevueltaLibro = DateTime.Now;

            paso = DevolucionesBLL.Guardar(devoluciones);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            DevolucionDetalles devolucionDetalles = new DevolucionDetalles(1, 1, 1, 1, "Oidsea version 1", DateTime.Now);
            List<DevolucionDetalles> list = new List<DevolucionDetalles>();

            list.Add(devolucionDetalles);
            Devoluciones devoluciones = new Devoluciones();
            devoluciones.DevolucionId = 10;
            devoluciones.FechaDevueltaLibro = DateTime.Now;
            paso = DevolucionesBLL.Modificar(devoluciones);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var paso = DevolucionesBLL.Eliminar(10);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = DevolucionesBLL.Buscar(10);
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
            var existe = DevolucionesBLL.Existe(10);
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