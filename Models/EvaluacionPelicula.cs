using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class EvaluacionPelicula
{
    public int IdEvaluacionPel { get; set; }

    public int IdPelicula { get; set; }

    public int IdCliente { get; set; }

    public int CalificacionPelicula { get; set; }

    public string DescEvaluacionPel { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Pelicula IdPeliculaNavigation { get; set; } = null!;
}
