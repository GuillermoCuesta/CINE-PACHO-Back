namespace WebApi.Models;

public partial class BoletasGrati
{
    public int ConsecBoletasg { get; set; }

    public int IdCliente { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public DateTime? FechaReclamo { get; set; }

    //public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
