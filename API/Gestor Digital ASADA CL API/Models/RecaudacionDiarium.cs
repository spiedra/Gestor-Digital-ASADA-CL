using System;
using System.Collections.Generic;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class RecaudacionDiarium
    {
        public int IdRecaudacion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaRecaudacion { get; set; }
        public string CantidadEfectivo { get; set; }
        public string CantidadTarjeta { get; set; }
        public string CantidadSinpe { get; set; }
        public string CantidadIva { get; set; }
        public int CuentaHidrantes { get; set; }
        public string TotalRecaudado { get; set; }
        public int? CantidadRecibos { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
