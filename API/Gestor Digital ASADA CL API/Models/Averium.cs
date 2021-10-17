using System;
using System.Collections.Generic;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class Averium
    {
        public Averium()
        {
            AveriaTrabajadors = new HashSet<AveriaTrabajador>();
        }

        public int IdAveria { get; set; }
        public int? IdSector { get; set; }
        public string Afectado { get; set; }
        public DateTime FechaReporte { get; set; }
        public string DetallesReporte { get; set; }
        public DateTime? FechaEjecucion { get; set; }
        public string TrabajoEjecutado { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Sector IdSectorNavigation { get; set; }
        public virtual ICollection<AveriaTrabajador> AveriaTrabajadors { get; set; }
    }
}
