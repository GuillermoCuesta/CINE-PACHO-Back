using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Item
{
    public int IdCompra { get; set; }

    public int IdItem { get; set; }

    public int IdSnack { get; set; }

    public int CantidadItem { get; set; }

    public virtual Compra IdCompraNavigation { get; set; } = null!;

    public virtual Snack IdSnackNavigation { get; set; } = null!;
}
