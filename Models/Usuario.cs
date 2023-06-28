using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Usuario
{
    public int? IdUsuario { get; set; }

    public int? CodEmpleado { get; set; }

    public string? ImagenUsuario { get; set; } = null!;

    public string? CorreoUsuario { get; set; } = null!;

    public string? ContrasenaUsuario { get; set; } = null!;

    public virtual Empleado? CodEmpleadoNavigation { get; set; }
}
