using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryServicesWeb_AP2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryServicesWeb_AP2.Models;

namespace LibraryServicesWeb_AP2.BLL.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso ;
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = 1;
            usuarios.Nombres = "Jenry";
            usuarios.NombreUsuario = "Jenry_Cacerez";
            usuarios.Nivel = "jefe";
            usuarios.Contraseña = "Jenry123";
            usuarios.Email = "Jenry@hotmail.com";
            usuarios.Celular = "Jenry";
            usuarios.Celular = "809-588-5061";
            usuarios.FechaInsercion = DateTime.Now;

            paso = UsuariosBLL.Guardar(usuarios);
            Assert.AreEqual(paso, true);
        }

       

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = 1;
            usuarios.Nombres = "Jenry";
            usuarios.NombreUsuario = "Jenry_Cacerez";
            usuarios.Nivel = "jefe";
            usuarios.Contraseña = "Jenry123";
            usuarios.Email = "Jenry@hotmail.com";
            usuarios.Celular = "Jenry";
            usuarios.Celular = "809-588-5061";

            usuarios.FechaInsercion = DateTime.Now;

           

            paso = UsuariosBLL.Modificar(usuarios);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var paso = UsuariosBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = UsuariosBLL.Buscar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Usuarios> lista = new List<Usuarios>();
            lista = UsuariosBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = UsuariosBLL.Existe(1);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetUsuariosTest()
        {
            List<Usuarios> lista = new List<Usuarios>();
            lista = UsuariosBLL.GetUsuarios();
            Assert.IsNotNull(lista);
        }
    }
}