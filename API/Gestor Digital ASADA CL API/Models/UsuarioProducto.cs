using System;
using System.Collections.Generic;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class UsuarioProducto
    {
        public string CodigoProducto { get; set; }
        public int IdUsuario { get; set; }
        public int Cantidad { get; set; }
        public string Detalles { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Producto CodigoProductoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
