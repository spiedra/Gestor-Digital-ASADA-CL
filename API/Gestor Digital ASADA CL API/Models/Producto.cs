using System;
using System.Collections.Generic;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class Producto
    {
        public Producto()
        {
            UsuarioProductos = new HashSet<UsuarioProducto>();
        }

        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string ValorUnitario { get; set; }
        public int Cantidad { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Descripcion { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<UsuarioProducto> UsuarioProductos { get; set; }
    }
}
