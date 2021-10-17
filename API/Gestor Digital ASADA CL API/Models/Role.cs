using System;
using System.Collections.Generic;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class Role
    {
        public Role()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRole { get; set; }
        public string TipoRole { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
