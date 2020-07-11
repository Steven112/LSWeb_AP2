using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.Models
{
    public class Categoria
    {

        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacio")]
        [Range(0, 1000, ErrorMessage = "El Id debe estar entre 1 y 100")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El campo Descripcion no puede estar vacio")]
        [MaxLength(40, ErrorMessage = "La Descripcion excede la cantidad de caracteres")]
        [MinLength(3, ErrorMessage = "La Descripcion es muy corta")]
        public string Descripcion { get; set; }

        public int UsuarioId { get; set; }

        public Categoria()
        {
            CategoriaId = 0;
            Descripcion = string.Empty;
        }

        public Categoria(int categoriaId, string descripcion, int usuarioId)
        {
            CategoriaId = categoriaId;
            Descripcion = descripcion;
            UsuarioId = usuarioId;
        }
    }
}
