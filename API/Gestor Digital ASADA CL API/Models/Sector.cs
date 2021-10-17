using System;
using System.Collections.Generic;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class Sector
    {
        public Sector()
        {
            Averia = new HashSet<Averium>();
        }

        public int IdSector { get; set; }
        public string NombreSector { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Averium> Averia { get; set; }
    }
}
