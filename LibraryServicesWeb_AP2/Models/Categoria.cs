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
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }

        public Categoria()
        {
            CategoriaId = 0;
            Descripcion = string.Empty;
            UsuarioId = 0;
        }

        public Categoria(int categoriaId, string descripcion, int usuarioId)
        {
            CategoriaId = categoriaId;
            Descripcion = descripcion;
            UsuarioId = usuarioId;
        }
    }
}
