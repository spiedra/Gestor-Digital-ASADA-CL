using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL_API.Utility
{
    public class SolicitudProducto
    {
        public string NombreUsuario { get; set; }
        public string CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public string Detalles { get; set; }
        public DateTime Fecha { get; set; }

    }
}
