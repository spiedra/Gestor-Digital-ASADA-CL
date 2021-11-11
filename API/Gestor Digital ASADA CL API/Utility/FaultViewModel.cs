using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL_API.Utility
{
    public class FaultViewModel
    {

        public int? IdSector { get; set; }
        public int IdAveria { get; set; }
        public int IdTrabajador { get; set; }
        public string Afectado { get; set; }
       
        public DateTime FechaReporte { get; set; }
       
        public string DetallesReporte { get; set; }
       
        public DateTime? FechaEjecucion { get; set; }
        
        public string TrabajoEjecutado { get; set; }
        public bool? IsDelete { get; set; }
    }
}
