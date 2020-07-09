using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.Models
{
    public class Prestamo
    {
        [Key]
        public int PrestamoId { get; set; }
        public int EstudianteId { get; set; }
        //[ForeignKey("EstudianteId")]
        //public Estudiante Estudiante { get; set; }
        public int LibroId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public virtual List<PrestamosDetalle> Detalle { get; set; }
        public int UsuarioId { get; set; }

        public Prestamo(int prestamoId, int estudianteId, int libroId, DateTime fechaPrestamo, DateTime fechaDevolucion, List<PrestamosDetalle> detalle)
        {
            PrestamoId = prestamoId;
            EstudianteId = estudianteId;
            // Estudiante = estudiante;
            LibroId = libroId;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
            Detalle = detalle;
        }

        public Prestamo()
        {
        }
        public class PrestamosDetalle
        {
            [Key]
            public int DetalleId { get; set; }
            public int LibroId { get; set; }
            public DateTime FechaDevolucion { get; set; }

            public PrestamosDetalle(int detalleId, int libroId, DateTime fechaDevolucion)
            {
                DetalleId = detalleId;
                LibroId = libroId;
                FechaDevolucion = fechaDevolucion;
            }

            public PrestamosDetalle()
            {
                DetalleId = 0;
                LibroId = 0;
                FechaDevolucion = DateTime.Now;

            }
        }
    }
}
