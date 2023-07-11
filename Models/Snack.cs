namespace WebApi.Models;

public partial class Snack
{
    public int IdSnack { get; set; }

    public string NombreSnack { get; set; } = null!;

    public int PrecioSnack { get; set; }

    public string ImagenSnack { get; set; } = null!;

    public int? CantidadInStock { get; set; }

    //public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    //public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
