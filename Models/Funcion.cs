using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Funcion
{
    public int? IdFuncion { get; set; }

    public int? IdMultiplex { get; set; }

    public int? NumSala { get; set; }

    public int? IdPelicula { get; set; }

    public string? Estado { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string? Ubicacion { get; set; }
    public string? NombrePelicula { get; set; }

    public string? ImagenPelicula { get; set; }

    //public virtual Estado EstadoNavigation { get; set; } = null!;

    //public virtual Pelicula IdPeliculaNavigation { get; set; } = null!;

    //public virtual Sala Sala { get; set; } = null!;
}
