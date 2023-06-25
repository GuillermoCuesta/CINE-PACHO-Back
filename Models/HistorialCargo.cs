using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class HistorialCargo
{
    public int ConsecHistorial { get; set; }

    public int CodEmpleado { get; set; }

    public string Cargo { get; set; } = null!;

    public DateTime FechaAsignacion { get; set; }

    public virtual Cargo CargoNavigation { get; set; } = null!;

    public virtual Empleado CodEmpleadoNavigation { get; set; } = null!;
}
