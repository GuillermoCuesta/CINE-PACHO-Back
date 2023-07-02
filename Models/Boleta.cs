using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Boleta
{
    public int IdBoleta { get; set; }

    public int IdCompra { get; set; }

    public int IdMultiplex { get; set; }

    public int NumSala { get; set; }

    public string NumSilla { get; set; } = null!;

    public int CantidadBoleta { get; set; }

    //public virtual Compra IdCompraNavigation { get; set; } = null!;

    //public virtual Silla Silla { get; set; } = null!;
}
