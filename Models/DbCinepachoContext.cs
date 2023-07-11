using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public partial class DbCinepachoContext : DbContext
{
    public DbCinepachoContext()
    {
    }

    public DbCinepachoContext(DbContextOptions<DbCinepachoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BoletasGrati> BoletasGratis { get; set; }

    public virtual DbSet<Boleta> Boleta { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<EvaluacionPelicula> EvaluacionPeliculas { get; set; }

    public virtual DbSet<EvaluacionServicio> EvaluacionServicios { get; set; }

    public virtual DbSet<Funcion> Funcions { get; set; }

    public virtual DbSet<HistorialCargo> HistorialCargos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Multiplex> Multiplexes { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<RegistroPunto> RegistroPuntos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<Silla> Sillas { get; set; }

    public virtual DbSet<Snack> Snacks { get; set; }

    public virtual DbSet<TipoSilla> TipoSillas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:cinepacho-server.database.windows.net,1433;Initial Catalog=DB_CINEPACHO;Persist Security Info=False;User ID=ADMIN_CINEPACHO;Password= cine2023PACHO;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BoletasGrati>(
            entity =>
        {
            //    entity.HasKey(e => e.ConsecBoletasg);

            //    entity.ToTable("BOLETAS_GRATIS");

            //    entity.HasIndex(e => e.IdCliente, "CLIENTE_BOLETASGRATIS_FK");

            //    entity.Property(e => e.ConsecBoletasg)
            //        .ValueGeneratedNever()
            //        .HasColumnName("CONSEC_BOLETASG");
            //    entity.Property(e => e.FechaReclamo)
            //        .HasColumnType("datetime")
            //        .HasColumnName("FECHA_RECLAMO");
            //    entity.Property(e => e.FechaVencimiento)
            //        .HasColumnType("datetime")
            //        .HasColumnName("FECHA_VENCIMIENTO");
            //    entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

            //    entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.BoletasGratis)
            //        .HasForeignKey(d => d.IdCliente)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_BOLETAS__CLIENTE_B_CLIENTE");
        });

        modelBuilder.Entity<Boleta>(entity =>
        {
            //    entity.HasKey(e => e.IdBoleta);

            //    entity.ToTable("BOLETA");

            //    entity.HasIndex(e => e.IdCompra, "COMPRA_BOLETA_FK");

            //    entity.HasIndex(e => new { e.IdMultiplex, e.NumSala, e.NumSilla }, "SILLA_BOLETA_FK");

            //    entity.Property(e => e.IdBoleta)
            //        .ValueGeneratedNever()
            //        .HasColumnName("ID_BOLETA");
            //    entity.Property(e => e.CantidadBoleta).HasColumnName("CANTIDAD_BOLETA");
            //    entity.Property(e => e.IdCompra).HasColumnName("ID_COMPRA");
            //    entity.Property(e => e.IdMultiplex).HasColumnName("ID_MULTIPLEX");
            //    entity.Property(e => e.NumSala).HasColumnName("NUM_SALA");
            //    entity.Property(e => e.NumSilla)
            //        .HasMaxLength(3)
            //        .IsUnicode(false)
            //        .HasColumnName("NUM_SILLA");

            //    entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.Boleta)
            //        .HasForeignKey(d => d.IdCompra)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_BOLETA_COMPRA_BO_COMPRA");

            //    entity.HasOne(d => d.Silla).WithMany(p => p.Boleta)
            //        .HasForeignKey(d => new { d.IdMultiplex, d.NumSala, d.NumSilla })
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_BOLETA_SILLA_BOL_SILLA");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            //    entity.HasKey(e => e.Cargo1);

            //    entity.ToTable("CARGO");

            //    entity.Property(e => e.Cargo1)
            //        .HasMaxLength(30)
            //        .IsUnicode(false)
            //        .HasColumnName("CARGO");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            //    entity.HasKey(e => e.IdCliente);

            //    entity.ToTable("CLIENTE");

            //    entity.Property(e => e.IdCliente)
            //        .ValueGeneratedNever()
            //        .HasColumnName("ID_CLIENTE");
            //    entity.Property(e => e.CedulaCliente).HasColumnName("CEDULA_CLIENTE");
            //    entity.Property(e => e.NombreCliente)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .HasColumnName("NOMBRE_CLIENTE");
            //    entity.Property(e => e.NumTelefonoCliente).HasColumnName("NUM_TELEFONO_CLIENTE");
            //    entity.Property(e => e.Puntos).HasColumnName("PUNTOS");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            //    entity.HasKey(e => e.IdCompra);

            //    entity.ToTable("COMPRA");

            //    entity.HasIndex(e => e.IdCliente, "CLIENTE_COMPRA_FK");

            //    entity.Property(e => e.IdCompra)
            //        .ValueGeneratedNever()
            //        .HasColumnName("ID_COMPRA");
            //    entity.Property(e => e.FechaCompra)
            //        .HasColumnType("datetime")
            //        .HasColumnName("FECHA_COMPRA");
            //    entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            //    entity.Property(e => e.TotalCompra)
            //        .HasColumnType("decimal(30, 3)")
            //        .HasColumnName("TOTAL_COMPRA");

            //    entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Compras)
            //        .HasForeignKey(d => d.IdCliente)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_COMPRA_CLIENTE_C_CLIENTE");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            //    entity.HasKey(e => e.CodEmpleado);

            //    entity.ToTable("EMPLEADO");

            //    entity.HasIndex(e => e.Cargo, "CARGO_EMPLEADO_FK");

            //    entity.HasIndex(e => e.IdMultiplex, "MULTIPLEX_EMPLEADO_FK");

            //    entity.HasIndex(e => e.Rol, "ROL_EMPLEADO_FK");

            //    entity.Property(e => e.CodEmpleado)
            //        .ValueGeneratedNever()
            //        .HasColumnName("COD_EMPLEADO");
            //    entity.Property(e => e.Cargo)
            //        .HasMaxLength(30)
            //        .IsUnicode(false)
            //        .HasColumnName("CARGO");
            //    entity.Property(e => e.Cedula).HasColumnName("CEDULA");
            //    entity.Property(e => e.FechaContrato)
            //        .HasColumnType("datetime")
            //        .HasColumnName("FECHA_CONTRATO");
            //    entity.Property(e => e.IdMultiplex).HasColumnName("ID_MULTIPLEX");
            //    entity.Property(e => e.NombreEmpleado)
            //        .HasMaxLength(45)
            //        .IsUnicode(false)
            //        .HasColumnName("NOMBRE_EMPLEADO");
            //    entity.Property(e => e.NumTelefono).HasColumnName("NUM_TELEFONO");
            //    entity.Property(e => e.Rol)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .HasColumnName("ROL");
            //    entity.Property(e => e.Salario)
            //        .HasColumnType("decimal(30, 3)")
            //        .HasColumnName("SALARIO");

            //    entity.HasOne(d => d.CargoNavigation).WithMany(p => p.Empleados)
            //        .HasForeignKey(d => d.Cargo)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_EMPLEADO_CARGO_EMP_CARGO");

            //    entity.HasOne(d => d.IdMultiplexNavigation).WithMany(p => p.Empleados)
            //        .HasForeignKey(d => d.IdMultiplex)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_EMPLEADO_MULTIPLEX_MULTIPLE");

            //    entity.HasOne(d => d.RolNavigation).WithMany(p => p.Empleados)
            //        .HasForeignKey(d => d.Rol)
            //        .HasConstraintName("FK_EMPLEADO_ROL_EMPLE_ROL");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            //    entity.HasKey(e => e.Estado1);

            //    entity.ToTable("ESTADO");

            //    entity.Property(e => e.Estado1)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .HasColumnName("ESTADO");
        });

        modelBuilder.Entity<EvaluacionPelicula>(entity =>
        {
            //    entity.HasKey(e => e.IdEvaluacionPel);

            //    entity.ToTable("EVALUACION_PELICULA");

            //    entity.HasIndex(e => e.IdCliente, "CLIENTE_EVALUACIONPELI_FK");

            //    entity.HasIndex(e => e.IdPelicula, "PELICULA_EVALUACIONPELI_FK");

            //    entity.Property(e => e.IdEvaluacionPel)
            //        .ValueGeneratedNever()
            //        .HasColumnName("ID_EVALUACION_PEL");
            //    entity.Property(e => e.CalificacionPelicula).HasColumnName("CALIFICACION_PELICULA");
            //    entity.Property(e => e.DescEvaluacionPel)
            //        .HasColumnType("text")
            //        .HasColumnName("DESC_EVALUACION_PEL");
            //    entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            //    entity.Property(e => e.IdPelicula).HasColumnName("ID_PELICULA");

            //    entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.EvaluacionPeliculas)
            //        .HasForeignKey(d => d.IdCliente)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_PELIEVALUI_CLIENTE_E_CLIENTE");

            //    entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.EvaluacionPeliculas)
            //        .HasForeignKey(d => d.IdPelicula)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_EVALUACI_PELICULA__PELICULA");
        });

        modelBuilder.Entity<EvaluacionServicio>(entity =>
        {
            //    entity.HasKey(e => e.IdEvaluacionSer);

            //    entity.ToTable("EVALUACION_SERVICIO");

            //    entity.HasIndex(e => e.IdCliente, "CLIENTE_EVALUACIONSERVI_FK");

            //    entity.HasIndex(e => e.IdCompra, "COMPRA_EVALUACIONSERVI_FK");

            //    entity.Property(e => e.IdEvaluacionSer)
            //        .ValueGeneratedNever()
            //        .HasColumnName("ID_EVALUACION_SER");
            //    entity.Property(e => e.CalificacionServicio).HasColumnName("CALIFICACION_SERVICIO");
            //    entity.Property(e => e.DescEvaluacionSer)
            //        .HasColumnType("text")
            //        .HasColumnName("DESC_EVALUACION_SER");
            //    entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            //    entity.Property(e => e.IdCompra).HasColumnName("ID_COMPRA");

            //    entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.EvaluacionServicios)
            //        .HasForeignKey(d => d.IdCliente)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_SERVIEVALU_CLIENTE_S_CLIENTE");

            //    entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.EvaluacionServicios)
            //        .HasForeignKey(d => d.IdCompra)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_EVALUACI_COMPRA_EV_COMPRA");
        });

        modelBuilder.Entity<Funcion>(entity =>
        {
            //    entity.HasKey(e => e.IdFuncion);

            //    entity.ToTable("FUNCION");

            //    entity.HasIndex(e => e.Estado, "ESTADO_FUNCION_FK");

            //    entity.HasIndex(e => e.IdPelicula, "PELICULA_FUNCION_FK");

            //    entity.HasIndex(e => new { e.IdMultiplex, e.NumSala }, "SALA_FUNCION_FK");

            //    entity.Property(e => e.IdFuncion)
            //        .ValueGeneratedNever()
            //        .HasColumnName("ID_FUNCION");
            //    entity.Property(e => e.Estado)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .HasColumnName("ESTADO");
            //    entity.Property(e => e.FechaFin)
            //        .HasColumnType("datetime")
            //        .HasColumnName("FECHA_FIN");
            //    entity.Property(e => e.FechaInicio)
            //        .HasColumnType("datetime")
            //        .HasColumnName("FECHA_INICIO");
            //    entity.Property(e => e.IdMultiplex).HasColumnName("ID_MULTIPLEX");
            //    entity.Property(e => e.IdPelicula).HasColumnName("ID_PELICULA");
            //    entity.Property(e => e.NumSala).HasColumnName("NUM_SALA");

            //    entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Funcions)
            //        .HasForeignKey(d => d.Estado)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_FUNCION_ESTADO_FU_ESTADO");

            //    entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.Funcions)
            //        .HasForeignKey(d => d.IdPelicula)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_FUNCION_PELICULA__PELICULA");

            //    entity.HasOne(d => d.Sala).WithMany(p => p.Funcions)
            //        .HasForeignKey(d => new { d.IdMultiplex, d.NumSala })
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_FUNCION_SALA_FUNC_SALA");
        });

        modelBuilder.Entity<HistorialCargo>(entity =>
        {
            //    entity.HasKey(e => e.ConsecHistorial);

            //    entity.ToTable("HISTORIAL_CARGOS");

            //    entity.HasIndex(e => e.Cargo, "CARGO_HISTORIAL_FK");

            //    entity.HasIndex(e => e.CodEmpleado, "EMPLEADO_HISTORIALCAR_FK");

            //    entity.Property(e => e.ConsecHistorial)
            //        .ValueGeneratedNever()
            //        .HasColumnName("CONSEC_HISTORIAL");
            //    entity.Property(e => e.Cargo)
            //        .HasMaxLength(30)
            //        .IsUnicode(false)
            //        .HasColumnName("CARGO");
            //    entity.Property(e => e.CodEmpleado).HasColumnName("COD_EMPLEADO");
            //    entity.Property(e => e.FechaAsignacion)
            //        .HasColumnType("datetime")
            //        .HasColumnName("FECHA_ASIGNACION");

            //    entity.HasOne(d => d.CargoNavigation).WithMany(p => p.HistorialCargos)
            //        .HasForeignKey(d => d.Cargo)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_HISTORIA_CARGO_HIS_CARGO");

            //    entity.HasOne(d => d.CodEmpleadoNavigation).WithMany(p => p.HistorialCargos)
            //        .HasForeignKey(d => d.CodEmpleado)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_HISTORIA_EMPLEADO__EMPLEADO");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            //entity.HasKey(e => new { e.IdSnack, e.IdMultiplex, e.CantidadEnStock });

            //entity.ToTable("INVENTARIO");

            //entity.HasIndex(e => e.IdMultiplex, "MULTIPLEX_INVENTARIO_FK");

            //entity.HasIndex(e => e.IdSnack, "SNACK_INVENTARIO_FK");

            //entity.Property(e => e.IdSnack).HasColumnName("ID_SNACK");
            //entity.Property(e => e.IdMultiplex).HasColumnName("ID_MULTIPLEX");
            //entity.Property(e => e.CantidadEnStock).HasColumnName("CANTIDAD_EN_STOCK");

            //entity.HasOne(d => d.IdMultiplexNavigation).WithMany(p => p.Inventarios)
            //    .HasForeignKey(d => d.IdMultiplex)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_INVENTAR_MULTIPLEX_MULTIPLE");

            //entity.HasOne(d => d.IdSnackNavigation).WithMany(p => p.Inventarios)
            //    .HasForeignKey(d => d.IdSnack)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_INVENTAR_SNACK_INV_SNACK");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            //entity.HasKey(e => new { e.IdCompra, e.IdItem });

            //entity.ToTable("ITEM");

            //entity.HasIndex(e => e.IdCompra, "COMPRA_ITEM_FK");

            //entity.HasIndex(e => e.IdSnack, "SNACK_ITEM_FK");

            //entity.Property(e => e.IdCompra).HasColumnName("ID_COMPRA");
            //entity.Property(e => e.IdItem).HasColumnName("ID_ITEM");
            //entity.Property(e => e.CantidadItem).HasColumnName("CANTIDAD_ITEM");
            //entity.Property(e => e.IdSnack).HasColumnName("ID_SNACK");

            //entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.Items)
            //    .HasForeignKey(d => d.IdCompra)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_ITEM_COMPRA_IT_COMPRA");

            //entity.HasOne(d => d.IdSnackNavigation).WithMany(p => p.Items)
            //    .HasForeignKey(d => d.IdSnack)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_ITEM_SNACK_ITE_SNACK");
        });

        modelBuilder.Entity<Multiplex>(entity =>
        {
            //entity.HasKey(e => e.IdMultiplex);

            //entity.ToTable("MULTIPLEX");

            //entity.Property(e => e.IdMultiplex)
            //    .ValueGeneratedNever()
            //    .HasColumnName("ID_MULTIPLEX");
            //entity.Property(e => e.Direccion)
            //    .HasMaxLength(30)
            //    .IsUnicode(false)
            //    .HasColumnName("DIRECCION");
            //entity.Property(e => e.ImagenMultiplex)
            //    .HasMaxLength(255)
            //    .IsUnicode(false)
            //    .HasColumnName("IMAGEN_MULTIPLEX");
            //entity.Property(e => e.Ubicacion)
            //    .HasMaxLength(30)
            //    .IsUnicode(false)
            //    .HasColumnName("UBICACION");
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            //entity.HasKey(e => e.IdPelicula);

            //entity.ToTable("PELICULA");

            //entity.Property(e => e.IdPelicula)
            //    .ValueGeneratedNever()
            //    .HasColumnName("ID_PELICULA");
            //entity.Property(e => e.Duracion).HasColumnName("DURACION");
            //entity.Property(e => e.ImagenPelicula)
            //    .HasMaxLength(255)
            //    .IsUnicode(false)
            //    .HasColumnName("IMAGEN_PELICULA");
            //entity.Property(e => e.NombrePelicula)
            //    .HasMaxLength(30)
            //    .IsUnicode(false)
            //    .HasColumnName("NOMBRE_PELICULA");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            //entity.HasKey(e => e.IdPermiso);

            //entity.ToTable("PERMISO");

            //entity.Property(e => e.IdPermiso)
            //    .ValueGeneratedNever()
            //    .HasColumnName("ID_PERMISO");
        });

        modelBuilder.Entity<RegistroPunto>(entity =>
        {
            //entity.HasKey(e => e.IdRegistro);

            //entity.ToTable("REGISTRO_PUNTOS");

            //entity.HasIndex(e => e.IdCliente, "CLEINTE_REGISTRO_PUN_FK");

            //entity.Property(e => e.IdRegistro)
            //    .ValueGeneratedNever()
            //    .HasColumnName("ID_REGISTRO");
            //entity.Property(e => e.FechaRegistro)
            //    .HasColumnType("datetime")
            //    .HasColumnName("FECHA_REGISTRO");
            //entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            //entity.Property(e => e.PuntosObtenidos).HasColumnName("PUNTOS_OBTENIDOS");

            //entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.RegistroPuntos)
            //    .HasForeignKey(d => d.IdCliente)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_REGISTRO_CLIENTE_R_CLIENTE");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            //entity.HasKey(e => e.Rol1);

            //entity.ToTable("ROL");

            //entity.HasIndex(e => e.IdPermiso, "PERMISO_ROL_FK");

            //entity.Property(e => e.Rol1)
            //    .HasMaxLength(40)
            //    .IsUnicode(false)
            //    .HasColumnName("ROL");
            //entity.Property(e => e.IdPermiso).HasColumnName("ID_PERMISO");

            //entity.HasOne(d => d.IdPermisoNavigation).WithMany(p => p.Rols)
            //    .HasForeignKey(d => d.IdPermiso)
            //    .HasConstraintName("FK_ROL_PERMISO_R_PERMISO");
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            //entity.HasKey(e => new { e.IdMultiplex, e.NumSala });

            //entity.ToTable("SALA");

            //entity.HasIndex(e => e.IdMultiplex, "MULTIPLEX_SALA_FK");

            //entity.Property(e => e.IdMultiplex).HasColumnName("ID_MULTIPLEX");
            //entity.Property(e => e.NumSala).HasColumnName("NUM_SALA");
            //entity.Property(e => e.NumSillasGeneral).HasColumnName("NUM_SILLAS_GENERAL");
            //entity.Property(e => e.NumSillasPreferencial).HasColumnName("NUM_SILLAS_PREFERENCIAL");

            //entity.HasOne(d => d.IdMultiplexNavigation).WithMany(p => p.Salas)
            //    .HasForeignKey(d => d.IdMultiplex)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_SALA_MULTIPLEX_MULTIPLE");
        });

        modelBuilder.Entity<Silla>(entity =>
        {
            //entity.HasKey(e => new { e.IdMultiplex, e.NumSala, e.NumSilla });

            //entity.ToTable("SILLA");

            //entity.HasIndex(e => new { e.IdMultiplex, e.NumSala }, "SALA_SILLA_FK");

            //entity.HasIndex(e => e.TipoSilla, "TIPOSILLA_SILLA_FK");

            //entity.Property(e => e.IdMultiplex).HasColumnName("ID_MULTIPLEX");
            //entity.Property(e => e.NumSala).HasColumnName("NUM_SALA");
            //entity.Property(e => e.NumSilla)
            //    .HasMaxLength(3)
            //    .IsUnicode(false)
            //    .HasColumnName("NUM_SILLA");
            //entity.Property(e => e.TipoSilla)
            //    .HasMaxLength(20)
            //    .IsUnicode(false)
            //    .HasColumnName("TIPO_SILLA");

            //entity.HasOne(d => d.TipoSillaNavigation).WithMany(p => p.Sillas)
            //    .HasForeignKey(d => d.TipoSilla)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_SILLA_TIPOSILLA_TIPO_SIL");

            //entity.HasOne(d => d.Sala).WithMany(p => p.Sillas)
            //    .HasForeignKey(d => new { d.IdMultiplex, d.NumSala })
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_SILLA_SALA_SILL_SALA");
        });

        modelBuilder.Entity<Snack>(entity =>
        {
            //entity.HasKey(e => e.IdSnack);

            //entity.ToTable("SNACK");

            //entity.Property(e => e.IdSnack)
            //    .ValueGeneratedNever()
            //    .HasColumnName("ID_SNACK");
            //entity.Property(e => e.ImagenSnack)
            //    .HasMaxLength(255)
            //    .IsUnicode(false)
            //    .HasColumnName("IMAGEN_SNACK");
            //entity.Property(e => e.NombreSnack)
            //    .HasMaxLength(45)
            //    .IsUnicode(false)
            //    .HasColumnName("NOMBRE_SNACK");
            //entity.Property(e => e.PrecioSnack).HasColumnName("PRECIO_SNACK");
        });

        modelBuilder.Entity<TipoSilla>(entity =>
        {
            //entity.HasKey(e => e.TipoSilla1);

            //entity.ToTable("TIPO_SILLA");

            //entity.Property(e => e.TipoSilla1)
            //    .HasMaxLength(20)
            //    .IsUnicode(false)
            //    .HasColumnName("TIPO_SILLA");
            //entity.Property(e => e.PrecioSilla)
            //    .HasColumnType("decimal(30, 2)")
            //    .HasColumnName("PRECIO_SILLA");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            //entity.HasKey(e => e.IdUsuario);

            //entity.ToTable("USUARIOS");

            //entity.HasIndex(e => e.CodEmpleado, "USUARIO_EMPLEADO_FK");

            //entity.Property(e => e.IdUsuario)
            //    .ValueGeneratedNever()
            //    .HasColumnName("ID_USUARIO");
            //entity.Property(e => e.CodEmpleado).HasColumnName("COD_EMPLEADO");
            //entity.Property(e => e.ContrasenaUsuario)
            //    .HasMaxLength(10)
            //    .IsUnicode(false)
            //    .HasColumnName("CONTRASENA_USUARIO");
            //entity.Property(e => e.CorreoUsuario)
            //    .HasMaxLength(30)
            //    .IsUnicode(false)
            //    .HasColumnName("CORREO_USUARIO");
            //entity.Property(e => e.ImagenUsuario)
            //    .HasMaxLength(255)
            //    .IsUnicode(false)
            //    .HasColumnName("IMAGEN_USUARIO");

            //entity.HasOne(d => d.CodEmpleadoNavigation).WithMany(p => p.Usuarios)
            //    .HasForeignKey(d => d.CodEmpleado)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_USUARIOS_USUARIO_E_EMPLEADO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
