using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryServicesWeb_AP2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryServicesWeb_AP2.Models;

namespace LibraryServicesWeb_AP2.BLL.Tests
{
    [TestClass()]
    public class EstudiantesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Estudiante estudiante = new Estudiante ();
            estudiante.EstudianteId = 2;
            estudiante.Nombres = "Jenry";
            estudiante.Apellidos = "Cacerez";
            estudiante.Celular = "829-638-2495";
            estudiante.Email = "Jenry_cacerez@hotmail.com";
            estudiante.Direccion = "calle 8 # 179";
            estudiante.Matricula= "2015-0066";
         
            estudiante.FechaInsercion = DateTime.Now;

            paso = EstudiantesBLL.Guardar(estudiante);
            Assert.AreEqual(paso, true);
           
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Estudiante estudiante = new Estudiante();
            estudiante.EstudianteId= 2;
            estudiante.Nombres = "Jenry";
            estudiante.Apellidos = "Cacerez";
            estudiante.Celular = "829-638-2495";
            estudiante.Email = "Jenry_cacerez@hotmail.com";
            estudiante.Direccion = "calle 8 # 179";
            estudiante.Matricula = "2015-0066";
            estudiante.FechaInsercion = DateTime.Now;

            paso = EstudiantesBLL.Modificar(estudiante);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var paso = EstudiantesBLL.Eliminar(2);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = EstudiantesBLL.Buscar(2);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Estudiante> lista = new List<Estudiante>();
            lista =EstudiantesBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = EstudiantesBLL.Existe(2);
            Assert.IsNotNull(existe);
        }

      
    }
}