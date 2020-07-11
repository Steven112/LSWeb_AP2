using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.Models
{
    public class Editorial
    {
        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int EditorialId { get; set; }

        [Required(ErrorMessage = "El campo Nombre no puede estar vacio")]
        [MaxLength(40, ErrorMessage = "El Nombre excede la cantidad de caracteres")]
        [MinLength(2, ErrorMessage = "Nombre muy corto")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Direccion no puede estar vacio")]
        [MaxLength(40, ErrorMessage = "La Direccion excede la cantidad de caracteres")]
        [MinLength(8, ErrorMessage = "La Direccion es muy corta")]
        public string Dirrecion { get; set; }

        public int UsuarioId { get; set; }

        public Editorial()
        {
            EditorialId = 0;
            Nombre = string.Empty;
            Dirrecion = string.Empty;
        }

        public Editorial(int editorialId, string nombre, string dirrecion, int usuarioId)
        {
            EditorialId = editorialId;
            Nombre = nombre;
            Dirrecion = dirrecion;
            UsuarioId = usuarioId;
        }
    }
}
