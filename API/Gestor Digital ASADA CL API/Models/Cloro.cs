using System;
using System.Collections.Generic;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class Cloro
    {
        public int IdCloroResidual { get; set; }
        public int? IdUsuario { get; set; }
        public string NombreCliente { get; set; }
        public int NumeroCasa { get; set; }
        public DateTime Fecha { get; set; }
        public string PorcentajeCloro { get; set; }
        public string Detalles { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
