using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.Models
{
    public class Libro
    {
        [Key]
        [Required(ErrorMessage = "El campo LibroId no puede estar vacio")]
        [Range(0,1000, ErrorMessage ="El Id debe estar entre 1 y 100")]
        public int LibroId { get; set; }

        [Required(ErrorMessage = "El campo Titulo Libro no puede estar vacio")]
        [MaxLength(100, ErrorMessage = "El Titulo excede la cantidad de caracteres")]
        [MinLength(2, ErrorMessage = "El Titulo es muy corto")]
        public string NombreLibro { get; set; }

        [Required(ErrorMessage = "El campo ISBN no puede estar vacio")]
        [MaxLength(10, ErrorMessage = "El ISBN excede la cantidad de caracteres")]
        [MinLength(4, ErrorMessage = "El ISBN es invalido (Muy corto)")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "El campo Categorias no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El campo Editorial no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int EditorialId { get; set; }


        [Required(ErrorMessage = "El campo Fecha Impresion no puede estar vacio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime FechaImpresion { get; set; }

        public bool Disponibilidad { get; set; }

        public int UsuarioId { get; set; }

        public Libro()
        {
            LibroId = 0;
            NombreLibro = string.Empty;
            ISBN = string.Empty;
            CategoriaId = 0;
            EditorialId = 0;
            FechaImpresion = DateTime.Now;
            Disponibilidad=false;
        }

        public Libro(int libroId, string nombreLibro, string iSBN, int categoriaId, int editorialId, DateTime fechaImpresion, bool disponibilidad, int usuarioId)
        {
            LibroId = libroId;
            NombreLibro = nombreLibro;
            ISBN = iSBN;
            CategoriaId = categoriaId;
            EditorialId = editorialId;
            FechaImpresion = fechaImpresion;
            Disponibilidad = disponibilidad;
            UsuarioId = usuarioId;
        }
    }
}
