using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class GestorDigitalASADACLAYDContext : DbContext
    {
        //public GestorDigitalASADACLAYDContext()
        //{
        //}

        public GestorDigitalASADACLAYDContext(DbContextOptions<GestorDigitalASADACLAYDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AveriaTrabajador> AveriaTrabajadors { get; set; }
        public virtual DbSet<Averium> Averia { get; set; }
        public virtual DbSet<BitacoraPersonal> BitacoraPersonals { get; set; }
        public virtual DbSet<CloroResidual> CloroResiduals { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<RecaudacionDiarium> RecaudacionDiaria { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioProducto> UsuarioProductos { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=163.178.107.10;Initial Catalog=GestorDigitalASADACL-AYD;Persist Security Info=True;User ID=laboratorios;Password=KmZpo.2796;Pooling=False");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<AveriaTrabajador>(entity =>
            {
                entity.HasKey(e => new { e.IdAveria, e.IdTrabajador })
                    .HasName("pk_id_averia_trabajador");

                entity.ToTable("AVERIA_TRABAJADOR", "ADMIN");

                entity.Property(e => e.IdAveria).HasColumnName("ID_AVERIA");

                entity.Property(e => e.IdTrabajador).HasColumnName("ID_TRABAJADOR");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("IS_DELETE")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdAveriaNavigation)
                    .WithMany(p => p.AveriaTrabajadors)
                    .HasForeignKey(d => d.IdAveria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_averia_averia");

                entity.HasOne(d => d.IdTrabajadorNavigation)
                    .WithMany(p => p.AveriaTrabajadors)
                    .HasForeignKey(d => d.IdTrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_trabajador_averia");
            });

            modelBuilder.Entity<Averium>(entity =>
            {
                entity.HasKey(e => e.IdAveria)
                    .HasName("PK__AVERIA__93BA53D944B5CAF7");

                entity.ToTable("AVERIA", "ADMIN");

                entity.Property(e => e.IdAveria).HasColumnName("ID_AVERIA");

                entity.Property(e => e.Afectado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AFECTADO");

                entity.Property(e => e.DetallesReporte)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DETALLES_REPORTE");

                entity.Property(e => e.FechaEjecucion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_EJECUCION");

                entity.Property(e => e.FechaReporte)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REPORTE");

                entity.Property(e => e.IdSector).HasColumnName("ID_SECTOR");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("IS_DELETE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TrabajoEjecutado)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("TRABAJO_EJECUTADO");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.Averia)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("fk_id_sector_averia");
            });

            modelBuilder.Entity<BitacoraPersonal>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BITACORA_PERSONAL", "ADMIN");

                entity.Property(e => e.Detalle)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DETALLE");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdBitacora)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_BITACORA");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("IS_DELETE")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario_bitacora");
            });

            modelBuilder.Entity<CloroResidual>(entity =>
            {
                entity.HasKey(e => e.IdCloroResidual)
                    .HasName("PK__CLORO_RE__97B168580227FA00");

                entity.ToTable("CLORO_RESIDUAL", "ADMIN");

                entity.Property(e => e.IdCloroResidual).HasColumnName("ID_CLORO_RESIDUAL");

                entity.Property(e => e.Detalles)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DETALLES");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("IS_DELETE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_CLIENTE");

                entity.Property(e => e.NumeroCasa).HasColumnName("NUMERO_CASA");

                entity.Property(e => e.PorcentajeCloro)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("PORCENTAJE_CLORO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.CloroResiduals)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_id_usuario_cloro");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoProducto)
                    .HasName("PK__PRODUCTO__DF3D23ECD09D0A98");

                entity.ToTable("PRODUCTO", "ADMIN");

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO_PRODUCTO");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_INGRESO");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("IS_DELETE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_PRODUCTO");

                entity.Property(e => e.ValorUnitario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VALOR_UNITARIO");
            });

            modelBuilder.Entity<RecaudacionDiarium>(entity =>
            {
                entity.HasKey(e => e.IdRecaudacion)
                    .HasName("PK__RECAUDAC__6B76070572F0CDA9");

                entity.ToTable("RECAUDACION_DIARIA", "ADMIN");

                entity.Property(e => e.IdRecaudacion).HasColumnName("ID_RECAUDACION");

                entity.Property(e => e.CantidadEfectivo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CANTIDAD_EFECTIVO");

                entity.Property(e => e.CantidadIva)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CANTIDAD_IVA");

                entity.Property(e => e.CantidadRecibos).HasColumnName("CANTIDAD_RECIBOS");

                entity.Property(e => e.CantidadSinpe)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CANTIDAD_SINPE");

                entity.Property(e => e.CantidadTarjeta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CANTIDAD_TARJETA");

                entity.Property(e => e.CuentaHidrantes).HasColumnName("CUENTA_HIDRANTES");

                entity.Property(e => e.FechaRecaudacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_RECAUDACION");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("IS_DELETE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalRecaudado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TOTAL_RECAUDADO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RecaudacionDiaria)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario_recaudacion");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__ROLE__C7D0F65781C0537D");

                entity.ToTable("ROLE", "ADMIN");

                entity.Property(e => e.IdRole).HasColumnName("ID_ROLE");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("IS_DELETE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoRole)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_ROLE");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.HasKey(e => e.IdSector)
                    .HasName("PK__SECTOR__F9D4159D60DAF487");

                entity.ToTable("SECTOR", "ADMIN");

                entity.Property(e => e.IdSector).HasColumnName("ID_SECTOR");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("IS_DELETE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NombreSector)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_SECTOR");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.IdTarea)
                    .HasName("PK__TAREA__3484F0F9F3E7791F");

                entity.ToTable("TAREA", "ADMIN");

                entity.Property(e => e.IdTarea).HasColumnName("ID_TAREA");

                entity.Property(e => e.Detalles)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DETALLES");

                entity.Property(e => e.FechaAsignacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_ASIGNACION");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("IS_DELETE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Realizada)
                    .HasColumnName("REALIZADA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario_tarea");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__91136B9087A49F7F");

                entity.ToTable("USUARIO", "ADMIN");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CEDULA");

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASENIA");

                entity.Property(e => e.IdRole).HasColumnName("ID_ROLE");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("IS_DELETE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_USUARIO");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_role");
            });

            modelBuilder.Entity<UsuarioProducto>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud)
                    .HasName("PK__USUARIO___F090D5845F3C24E3");

                entity.ToTable("USUARIO_PRODUCTO", "ADMIN");

                entity.Property(e => e.IdSolicitud).HasColumnName("ID_SOLICITUD");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.CodigoProducto)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO_PRODUCTO");

                entity.Property(e => e.Detalles)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DETALLES");

                entity.Property(e => e.FechaSolicitud)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_SOLICITUD");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("IS_DELETE")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CodigoProductoNavigation)
                    .WithMany(p => p.UsuarioProductos)
                    .HasForeignKey(d => d.CodigoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cod_producto_usuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioProductos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario_producto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
