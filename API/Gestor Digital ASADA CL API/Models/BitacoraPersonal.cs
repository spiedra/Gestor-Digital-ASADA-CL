using System;
using System.Collections.Generic;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class BitacoraPersonal
    {
        public int IdBitacora { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
