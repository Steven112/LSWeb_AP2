using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryServicesWeb_AP2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryServicesWeb_AP2.Models;

namespace LibraryServicesWeb_AP2.BLL.Tests
{
    [TestClass()]
    public class CategoriaBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Categoria categoria = new Categoria();
            categoria.CategoriaId = 10;
            categoria.Descripcion = "Novela";
           
            paso = CategoriaBLL.Guardar(categoria);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Categoria categoria = new Categoria();
            categoria.CategoriaId = 10;
            categoria.Descripcion = "Thriller";

            paso = CategoriaBLL.Modificar(categoria);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var paso = CategoriaBLL.Eliminar(10);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = CategoriaBLL.Buscar(10);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Categoria> lista = new List<Categoria>();
            lista = CategoriaBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = CategoriaBLL.Existe(1);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetCategoriaTest()
        {
            List<Categoria> lista = new List<Categoria>();
            lista = CategoriaBLL.GetCategoria();
            Assert.IsNotNull(lista);
        }
    }
}