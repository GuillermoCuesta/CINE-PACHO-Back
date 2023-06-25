using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Inventario
{
    public int IdSnack { get; set; }

    public int IdMultiplex { get; set; }

    public int CantidadEnStock { get; set; }

    public virtual Multiplex IdMultiplexNavigation { get; set; } = null!;

    public virtual Snack IdSnackNavigation { get; set; } = null!;
}
