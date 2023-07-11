namespace WebApi.Models
{
    public class CompraCliente
    {
        public int? IdCompra { get; set; }
        public int? IdCliente { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal? TotalCompra { get; set; }
        public string? NombreCliente { get; set; }
        public int? NumTelefonoCliente { get; set; }
        public int? CedulaCliente { get; set; }
        public int? Puntos { get; set; }
        public int? IdMultiplex { get; set; }
        public int? IdSala { get; set; }
        public List<Silla> Sillas { get; set; }
        public List<Tuple<int, int>> Snacks { get; set; }

    }
}
