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
        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "El campo Nombre no puede estar vacio")]
        [MaxLength(40, ErrorMessage = "El Nombre excede la cantidad de caracteres")]
        [MinLength(2, ErrorMessage = "Nombre muy corto")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo Apellido no puede estar vacio")]
        [MaxLength(40, ErrorMessage = "El nombre excede la cantidad de caracteres")]
        [MinLength(2, ErrorMessage = "Apellido muy corto")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo Matricula no puede estar vacio")]
        [MaxLength(9, ErrorMessage = "La Matricula excede la cantidad de caracteres")]
        [MinLength(8, ErrorMessage = "Matricula incorrecta")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "El campo Celular no puede estar vacio")]
        [MaxLength(11, ErrorMessage = "El Celular excede la cantidad de caracteres")]
        [MinLength(10, ErrorMessage = "El telefono esta incompleto")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El campo Direccion no puede estar vacio")]
        [MaxLength(40, ErrorMessage = "La Direccion excede la cantidad de caracteres")]
        [MinLength(7, ErrorMessage = "La direccion es muy corta")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Email no puede estar vacio")]
        [MaxLength(40, ErrorMessage = "El Email excede la cantidad de caracteres")]
        [EmailAddress(ErrorMessage = "Introduzca una direccion valida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Fecha Insercion no puede estar vacio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime FechaInsercion { get; set; }


        public Estudiante()
        {
            EstudianteId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Matricula = string.Empty;
            Celular = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            FechaInsercion = DateTime.Now;
        }
    

        public Estudiante(int estudianteId, string nombres, string apellidos, string matricula, string celular, string direccion, string email, DateTime fechaInsercion)
        {
            EstudianteId = estudianteId;
            Nombres = nombres;
            Apellidos = apellidos;
            Matricula = matricula;
            Celular = celular;
            Direccion = direccion;
            Email = email;
            FechaInsercion = fechaInsercion;
        }
    }
}
