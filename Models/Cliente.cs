namespace WebApi.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public int NumTelefonoCliente { get; set; }

    public int CedulaCliente { get; set; }

    public int Puntos { get; set; }

    //public virtual ICollection<BoletasGrati> BoletasGratis { get; set; } = new List<BoletasGrati>();

    //public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    //public virtual ICollection<EvaluacionPelicula> EvaluacionPeliculas { get; set; } = new List<EvaluacionPelicula>();

    //public virtual ICollection<EvaluacionServicio> EvaluacionServicios { get; set; } = new List<EvaluacionServicio>();

    //public virtual ICollection<RegistroPunto> RegistroPuntos { get; set; } = new List<RegistroPunto>();
}
