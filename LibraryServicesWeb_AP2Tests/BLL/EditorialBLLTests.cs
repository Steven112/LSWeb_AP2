using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryServicesWeb_AP2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryServicesWeb_AP2.Models;

namespace LibraryServicesWeb_AP2.BLL.Tests
{
    [TestClass()]
    public class EditorialBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Editorial editorial = new Editorial();
            editorial.EditorialId = 10;
            editorial.Nombre = "Steven";
            editorial.Dirrecion = "Calle Mella";

            paso = EditorialBLL.Guardar(editorial);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Editorial editorial = new Editorial();
            editorial.EditorialId = 10;
            editorial.Nombre = "Steven";
            editorial.Dirrecion = "Calle Milla";

            paso = EditorialBLL.Modificar(editorial);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var paso = EditorialBLL.Eliminar(10);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = EditorialBLL.Buscar(10);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Editorial> lista = new List<Editorial>();
            lista = EditorialBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = EditorialBLL.Existe(1);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetCategoriaTest()
        {
            List<Editorial> lista = new List<Editorial>();
            lista = EditorialBLL.GetEditorial();
            Assert.IsNotNull(lista);
        }



    }
}