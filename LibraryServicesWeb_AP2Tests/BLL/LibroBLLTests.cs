using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryServicesWeb_AP2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryServicesWeb_AP2.Models;

namespace LibraryServicesWeb_AP2.BLL.Tests
{
    [TestClass()]
    public class LibroBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Libro libro = new Libro();
            libro.LibroId = 10;
            libro.NombreLibro = "Iliada";
            libro.ISBN = "4479966";
            libro.CategoriaId = 1;
            libro.EditorialId = 1;
            libro.FechaImpresion = DateTime.Now;
            libro.Disponibilidad = true;
            paso = LibroBLL.Guardar(libro);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Libro libro = new Libro();
            libro.LibroId = 10;
            libro.NombreLibro = "Iliada";
            libro.ISBN = "4479977";
            libro.CategoriaId = 1;
            libro.EditorialId = 1;
            libro.FechaImpresion = DateTime.Now;
            libro.Disponibilidad = true;
            paso = LibroBLL.Modificar(libro);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var paso = LibroBLL.Eliminar(10);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = LibroBLL.Buscar(10);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Libro> lista = new List<Libro>();
            lista = LibroBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = LibroBLL.Existe(10);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetLibrosTest()
        {
            List<Libro> lista = new List<Libro>();
            lista = LibroBLL.GetLibros();
            Assert.IsNotNull(lista);
        }
    }

}