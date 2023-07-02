using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public string NombrePelicula { get; set; } = null!;

    public int Duracion { get; set; }

    public string ImagenPelicula { get; set; } = null!;

    //public virtual ICollection<EvaluacionPelicula> EvaluacionPeliculas { get; set; } = new List<EvaluacionPelicula>();

    //public virtual ICollection<Funcion> Funcions { get; set; } = new List<Funcion>();
}
