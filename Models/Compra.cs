using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int IdCliente { get; set; }

    public DateTime FechaCompra { get; set; }

    public decimal TotalCompra { get; set; }

    public virtual ICollection<Boleta> Boleta { get; set; } = new List<Boleta>();

    public virtual ICollection<EvaluacionServicio> EvaluacionServicios { get; set; } = new List<EvaluacionServicio>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
