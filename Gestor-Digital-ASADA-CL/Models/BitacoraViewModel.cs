using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class BitacoraViewModel
    {
        public int IdBitacora { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreUsuario { get; set; }
    }
}
