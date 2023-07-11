namespace WebApi.Models;

public partial class EvaluacionServicio
{
    public int IdEvaluacionSer { get; set; }

    public int IdCliente { get; set; }

    public int IdCompra { get; set; }

    public int CalificacionServicio { get; set; }

    public string DescEvaluacionSer { get; set; } = null!;

    //public virtual Cliente IdClienteNavigation { get; set; } = null!;

    //public virtual Compra IdCompraNavigation { get; set; } = null!;
}
