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

        [Required(ErrorMessage = "El campo Id no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "El campo Fecha Prestamo no puede estar vacio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime FechaPrestamo { get; set; }

        [Required(ErrorMessage = "El campo Fecha Devuelta no puede estar vacio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime FechaDevolucion { get; set; }



        [ForeignKey("PrestamoId")]
        public virtual List<PrestamosDetalle> PrestamosDetalles { get; set; } = new List<PrestamosDetalle>();

        public Prestamo(int prestamoId, int estudianteId, DateTime fechaPrestamo, DateTime fechaDevolucion)
        {
            PrestamoId = prestamoId;
            EstudianteId = estudianteId;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
        }
        public Prestamo()
        {
            PrestamoId = 0;
            EstudianteId = 0;
            FechaPrestamo = DateTime.Now;
            FechaDevolucion = DateTime.Now;
        }

    }

    public class PrestamosDetalle
    {
        [Key]
        public int DetalleId { get; set; }


        [Required(ErrorMessage = "El campo Id no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "El campo LibroId no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int LibroId { get; set; }
        [ForeignKey("LibroId")]
        public Libro libro { get; set; }

        public string TituloLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }

        public PrestamosDetalle(int detalleId, int prestamoId, int libroId, Libro libro, string tituloLibro, DateTime fechaPrestamo, DateTime fechaDevolucion)
        {
            DetalleId = detalleId;
            PrestamoId = prestamoId;
            LibroId = libroId;
            this.libro = libro;
            TituloLibro = tituloLibro;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
        }

        public PrestamosDetalle()
        {
            DetalleId = 0;
            PrestamoId = 0;
            LibroId = 0;
            TituloLibro = string.Empty;
            FechaPrestamo = DateTime.Now;
            FechaDevolucion = DateTime.Now;

        }
    }

}