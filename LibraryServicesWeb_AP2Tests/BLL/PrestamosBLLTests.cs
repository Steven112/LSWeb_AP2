using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryServicesWeb_AP2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryServicesWeb_AP2.Models;

namespace LibraryServicesWeb_AP2.BLL.Tests
{
    [TestClass()]
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            PrestamosDetalle prestamosDetalle  = new PrestamosDetalle(1, 1, 1,1,"Oidsea",DateTime.Now,DateTime.Now);
            List<PrestamosDetalle> list = new List<PrestamosDetalle>(); 
           
            list.Add(prestamosDetalle);
            Prestamo prestamo = new Prestamo();
            prestamo.PrestamoId = 1;
            prestamo.EstudianteId = 1;
            prestamo.FechaPrestamo = DateTime.Now;
            prestamo.FechaDevolucion = DateTime.Now;
            paso = PrestamosBLL.Guardar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            PrestamosDetalle prestamosDetalle = new PrestamosDetalle(1, 1, 1, 1, "Oidsea", DateTime.Now, DateTime.Now);
            List<PrestamosDetalle> list = new List<PrestamosDetalle>();

            list.Add(prestamosDetalle);
            Prestamo prestamo = new Prestamo();
            prestamo.PrestamoId = 1;
            prestamo.EstudianteId = 1;
            prestamo.FechaPrestamo = DateTime.MinValue;
            prestamo.FechaDevolucion = DateTime.Now;
            paso = PrestamosBLL.Modificar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var paso = PrestamosBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = PrestamosBLL.Buscar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Prestamo> lista = new List<Prestamo>();
            lista = PrestamosBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = PrestamosBLL.Existe(1);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetPrestamoTest()
        {
            List<Prestamo> lista = new List<Prestamo>();
            lista = PrestamosBLL.GetPrestamo();
            Assert.IsNotNull(lista);
        }
    }
}