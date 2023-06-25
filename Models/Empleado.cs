using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Empleado
{
    public int CodEmpleado { get; set; }

    public string Cargo { get; set; } = null!;

    public int IdMultiplex { get; set; }

    public string? Rol { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public int Cedula { get; set; }

    public int NumTelefono { get; set; }

    public DateTime FechaContrato { get; set; }

    public decimal Salario { get; set; }

    public virtual Cargo CargoNavigation { get; set; } = null!;

    public virtual ICollection<HistorialCargo> HistorialCargos { get; set; } = new List<HistorialCargo>();

    public virtual Multiplex IdMultiplexNavigation { get; set; } = null!;

    public virtual Rol? RolNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
