namespace WebApi.Models;

public partial class Inventario
{
    public int? IdSnack { get; set; }

    public int? IdMultiplex { get; set; }

    public int? CantidadInStock { get; set; }
    public decimal? PrecioSnack { get; set; }
    public string? NombreSnack { get; set; }
    public string? Ubicacion { get; set; }

    //public virtual Multiplex IdMultiplexNavigation { get; set; } = null!;

    //public virtual Snack IdSnackNavigation { get; set; } = null!;
}
