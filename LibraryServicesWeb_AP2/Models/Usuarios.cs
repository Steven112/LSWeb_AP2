using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.Models
{
    public class Usuarios
    {
        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacio")]
        [Range(0,1000,ErrorMessage ="El Id debe de estar entre 1 y 100")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo nombre no puede estar vacio ")]
        [MaxLength(40,ErrorMessage ="El nombre es muy largo")]
        [MinLength(3,ErrorMessage ="El nombre es muy corto")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo Celular no puede estar vacio ")]
        [MaxLength(11, ErrorMessage = "El telefono excede la cantidad de digitos")]
        [MinLength(10, ErrorMessage = "Telefono incorecto")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El campo Email no puede estar vacio")]
        [MaxLength(30, ErrorMessage = "El Email excede la cantidad de caracteres")]
        [EmailAddress(ErrorMessage = "Introduzca una direccion valida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Nombre Usuario no puede estar vacio")]
        [MaxLength(25, ErrorMessage = "El Nombre Usuario excede la cantidad de caracteres")]
        [MinLength(3, ErrorMessage = "El Nombre Usuario es muy corto")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El campo Contraseña no puede estar vacio")]
        [MaxLength(40, ErrorMessage = "La Contraseña excede la cantidad de caracteres")]
        [MinLength(7, ErrorMessage = "Contraseña Inseguro")]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "El campo Fecha Insercion no puede estar vacio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime FechaInsercion { get; set; }

        [Required(ErrorMessage = "El campo Nivel no puede estar vacio")]
        public string Nivel { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            Celular = string.Empty;
            Email = string.Empty;
            NombreUsuario = string.Empty;
            Contraseña = string.Empty;
            FechaInsercion = DateTime.Now;
            Nivel = string.Empty;
        }

        public Usuarios(int usuarioId, string nombres, string celular, string email, string nombreUsuario, string contraseña, DateTime fechaInsercion, string nivel)
        {
            UsuarioId = usuarioId;
            Nombres = nombres;
            Celular = celular;
            Email = email;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            FechaInsercion = fechaInsercion;
            Nivel = nivel;
        }
    }
}
