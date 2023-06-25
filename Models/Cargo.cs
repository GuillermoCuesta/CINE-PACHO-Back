using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Cargo
{
    public string Cargo1 { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<HistorialCargo> HistorialCargos { get; set; } = new List<HistorialCargo>();
}
