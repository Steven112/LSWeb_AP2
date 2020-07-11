using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.Models
{
    public class Prestamo
    {
        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "El campo LibroId no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "El campo LibroId no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int LibroId { get; set; }

        [Required(ErrorMessage = "El campo Fecha Prestamo no puede estar vacio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime FechaPrestamo { get; set; }

        [Required(ErrorMessage = "El campo Fecha Devuelta no puede estar vacio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime FechaDevolucion { get; set; }
        public int UsuarioId { get; set; }

        public Prestamo()
        {
            PrestamoId = 0;
            LibroId = 0;
            FechaPrestamo = DateTime.Now;
            FechaDevolucion = DateTime.Now;
        }

        public Prestamo(int prestamoId, int libroId, DateTime fechaPrestamo, DateTime fechaDevolucion,  int usuarioId)
        {
            PrestamoId = prestamoId;
            LibroId = libroId;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
            UsuarioId = usuarioId;
        }




    }

    public class PrestamosDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int PrestamoId { get; set; }

        public int EstudianteId { get; set; }
        [ForeignKey("EstudianteID")]
        public Estudiante estudiante { get; set; }

        public int LibroId { get; set; }
        [ForeignKey("LibroId")]
        public Libro libro { get; set; }

        public DateTime FechaDevolucion { get; set; }

        public PrestamosDetalle(int detalleId, int prestamoId, int estudianteId, Estudiante estudiante, int libroId, Libro libro, DateTime fechaDevolucion)
        {
            DetalleId = detalleId;
            PrestamoId = prestamoId;
            EstudianteId = estudianteId;
            this.estudiante = estudiante;
            LibroId = libroId;
            this.libro = libro;
            FechaDevolucion = fechaDevolucion;
        }

        public PrestamosDetalle()
        {
            DetalleId = 0;
            PrestamoId = 0;
            EstudianteId = 0;
            LibroId = 0;
            FechaDevolucion = DateTime.Now;

        }
    }

}