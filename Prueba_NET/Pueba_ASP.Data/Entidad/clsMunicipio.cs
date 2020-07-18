using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pueba_ASP.Data.Entidad
{
    public class clsMunicipio
    {
        public int Codigo_Municipio { get; set; }
        public string Nombre_Municipio { get; set; }
        public bool Estado { get; set; }
        public int Codigo_Region { get; set; }
        public string Nombre_Region { get; set; }
        public string Mensaje { get; set; }
    }
}
