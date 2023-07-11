using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Multiplex
{
    public int? IdMultiplex { get; set; }

    public string? Ubicacion { get; set; } = null!;

    public string? Direccion { get; set; } = null!;

    public string? ImagenMultiplex { get; set; } = null!;

    //public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    //public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    //public virtual ICollection<Sala> Salas { get; set; } = new List<Sala>();
}
