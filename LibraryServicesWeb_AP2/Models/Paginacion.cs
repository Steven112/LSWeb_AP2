using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.Models
{
    public class Paginacion
    {
        public int Pagina { get; set; }
        public int Mostrar { get; set; }
        public Paginacion()
        {
            Pagina = 1;
            Mostrar = 2;
        }
    }
}
