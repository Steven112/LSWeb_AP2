using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.Models
{
    public class Devoluciones
    {
        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 0 y 100")]
        public int DevolucionId { get; set; }

        

        [Required(ErrorMessage = "El campo Fecha Devuelta no puede estar vacio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime FechaDevueltaLibro { get; set; }

        [ForeignKey("DevolucionId")]
        public virtual List<DevolucionDetalles> devolucionDetalles { get; set; } = new List<DevolucionDetalles>();


        public Devoluciones(int devolucionId, DateTime fechaDevueltaLibro, List<DevolucionDetalles> devolucionDetalles)
        {
            DevolucionId = devolucionId;
            FechaDevueltaLibro = fechaDevueltaLibro;
            this.devolucionDetalles = devolucionDetalles;
        }

        public Devoluciones()
        {
            DevolucionId = 0;
            devolucionDetalles = this.devolucionDetalles;
            FechaDevueltaLibro = DateTime.Now;
        }
    }

    public class DevolucionDetalles
    {

        [Key]
        public int DetalleId { get; set; }

        [Required(ErrorMessage = "El campo Devolucion no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 0 y 100")]
        public int DevolucionId { get; set; }

        [Required(ErrorMessage = "El campo Estudiante no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 0 y 100")]
        public int EstudianteId { get; set; }
        [ForeignKey("EstudianteId")]
        public Estudiante estudiante  { get; set; }


        [Required(ErrorMessage = "El campo Libro no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int LibroId { get; set; }
        [ForeignKey("LibroId")]
        public Libro libro { get; set; }

        [Required(ErrorMessage = "El campo Titulo Libro no puede estar vacio")]
        [MaxLength(40, ErrorMessage = "El Titulo excede la cantidad de caracteres")]
        [MinLength(3, ErrorMessage = "Matricula incorrecta")]
        public string NombreLibro { get; set; }


        [Required(ErrorMessage = "El campo Fecha Devuelta no puede estar vacio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime FechaDevueltaLibro { get; set; }

        public DevolucionDetalles()
        {
            DetalleId = 0;
            DevolucionId = 0;
            LibroId = 0;
            NombreLibro = string.Empty;
            FechaDevueltaLibro = DateTime.Now;
        }

        public DevolucionDetalles(int detalleId, int devolucionId,  int libroId, string nombreLibro, DateTime fechaDevueltaLibro)
        {
            DetalleId = detalleId;
            DevolucionId = devolucionId;
            LibroId = libroId;
            NombreLibro = nombreLibro;
            FechaDevueltaLibro = fechaDevueltaLibro;
        }
    }
}
