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
        public int EditorialId { get; set; }
        public string Nombre { get; set; }
        public string Dirrecion { get; set; }
        public int UsuarioId { get; set; }

        public Editorial()
        {
            EditorialId = 0;
            Nombre = string.Empty;
            Dirrecion = string.Empty;
            UsuarioId = 0;
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
