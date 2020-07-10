using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace LibraryServicesWeb_AP2.Models
{
    public class Estudiante
    {
        [Required(ErrorMessage = "Debe ingresar ID Estudiante")]
        public int EstudianteId { get; set; }
        [Required(ErrorMessage = "Es obligatorio Introducir el nombre ")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Es obligatorio Introducir el apellido ")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Es obligatorio Introducir la Matricula ")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "Es obligatorio Introducir la cedula")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Es obligatorio Introducir la Direccion ")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Es obligatorio Introducir el Email ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir una fecha")]
        public DateTime FechaInsercion { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuarios usuarios { get; set; }


        public Estudiante()
        {
        }

        public Estudiante(int estudianteId, string nombres, string apellidos, string matricula, string celular, string direccion, string email, DateTime fechaInsercion, int usuarioId, Usuarios usuarios)
        {
            EstudianteId = estudianteId;
            Nombres = nombres;
            Apellidos = apellidos;
            Matricula = matricula;
            Celular = celular;
            Direccion = direccion;
            Email = email;
            FechaInsercion = fechaInsercion;
            UsuarioId = usuarioId;
            this.usuarios = usuarios;
        }
    }
}
