using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Rol
{
    public string Rol1 { get; set; } = null!;

    public int? IdPermiso { get; set; }

    //public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    //public virtual Permiso? IdPermisoNavigation { get; set; }
}
