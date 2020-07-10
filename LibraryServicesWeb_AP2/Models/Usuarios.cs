using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.Models
{
    public class Usuarios
    {

        [Required(ErrorMessage = "Debe ingresar ID Estudiante")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Es obligatorio Introducir el nombre ")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Es obligatorio Introducir el celular ")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Es obligatorio Introducir el Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Es obligatorio Introducir la Contraseña ")]
        public string Contraseña { get; set; }
        public DateTime FechaInsercion { get; set; }
        public string Nivel { get; set; }

        public Usuarios()
        {
        }

        public Usuarios(int usuarioId, string nombres, string celular, string email, string contraseña, DateTime fechaInsercion, string nivel)
        {
            UsuarioId = usuarioId;
            Nombres = nombres;
            Celular = celular;
            Email = email;
            Contraseña = contraseña;
            FechaInsercion = fechaInsercion;
            Nivel = nivel;
        }
    }
}
