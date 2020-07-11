﻿using System;
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
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int DevolucionId { get; set; }

        public bool Disponible { get; set; }


        [Required(ErrorMessage = "El campo Fecha Devuelta no puede estar vacio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime FechaDevueltaLibro { get; set; }

        [ForeignKey("DevolucionId")]
        public virtual List<DevolucionDetalles> devolucionDetalles { get; set; } = new List<DevolucionDetalles>();

        public int UsuarioId { get; set; }

        public Devoluciones(int devolucionId, bool disponible, DateTime fechaDevueltaLibro, List<DevolucionDetalles> devolucionDetalles, int usuarioId)
        {
            DevolucionId = devolucionId;
            Disponible = disponible;
            FechaDevueltaLibro = fechaDevueltaLibro;
            this.devolucionDetalles = devolucionDetalles;
            UsuarioId = usuarioId;
        }

        public Devoluciones()
        {
            DevolucionId = 0;
            Disponible = true;
            devolucionDetalles = this.devolucionDetalles;
            FechaDevueltaLibro = DateTime.Now;
        }
    }

    public class DevolucionDetalles
    {

        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int DetalleId { get; set; }

        [Required(ErrorMessage = "El campo Prestamo no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int DevolucionId { get; set; }

        [Required(ErrorMessage = "El campo Prestamo no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int PrestamoId { get; set; }
        [ForeignKey("PrestamoId")]
        public Prestamo prestamo { get; set; }

        [Required(ErrorMessage = "El campo Libro no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int LibroId { get; set; }

        [Required(ErrorMessage = "El campo Titulo Libro no puede estar vacio")]
        [MaxLength(40, ErrorMessage = "El Titulo excede la cantidad de caracteres")]
        [MinLength(3, ErrorMessage = "Matricula incorrecta")]
        public string NombreLibro { get; set; }

        [Required(ErrorMessage = "El campo Fecha Devolucion no puede estar vacio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime FechaDevolucionLibro { get; set; }

        [Required(ErrorMessage = "El campo Fecha Devuelta no puede estar vacio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime FechaDevueltaLibro { get; set; }

        public DevolucionDetalles()
        {
            DetalleId = 0;
            DevolucionId = 0;
            PrestamoId = 0;
            LibroId = 0;
            NombreLibro = string.Empty;
            FechaDevolucionLibro = DateTime.Now;
            FechaDevueltaLibro = DateTime.Now;
        }

        public DevolucionDetalles(int detalleId, int devolucionId, int prestamoId, int libroId, string nombreLibro, DateTime fechaDevolucionLibro, DateTime fechaDevueltaLibro)
        {
            DetalleId = detalleId;
            DevolucionId = devolucionId;
            PrestamoId = prestamoId;
            LibroId = libroId;
            NombreLibro = nombreLibro;
            FechaDevolucionLibro = fechaDevolucionLibro;
            FechaDevueltaLibro = fechaDevueltaLibro;
        }
    }
}