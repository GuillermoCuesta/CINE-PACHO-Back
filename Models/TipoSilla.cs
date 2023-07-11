namespace WebApi.Models;

public partial class TipoSilla
{
    public string TipoSilla1 { get; set; } = null!;

    public decimal PrecioSilla { get; set; }

    //public virtual ICollection<Silla> Sillas { get; set; } = new List<Silla>();
}
