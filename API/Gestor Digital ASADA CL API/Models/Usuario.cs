using System;
using System.Collections.Generic;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            AveriaTrabajadors = new HashSet<AveriaTrabajador>();
            CloroResiduals = new HashSet<Cloro>();
            RecaudacionDiaria = new HashSet<RecaudacionDiaria>();
            Tareas = new HashSet<Tarea>();
            UsuarioProductos = new HashSet<UsuarioProducto>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public int IdRole { get; set; }

        public bool? IsDelete { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<AveriaTrabajador> AveriaTrabajadors { get; set; }
        public virtual ICollection<Cloro> CloroResiduals { get; set; }
        public virtual ICollection<RecaudacionDiaria> RecaudacionDiaria { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
        public virtual ICollection<UsuarioProducto> UsuarioProductos { get; set; }
    }
}
