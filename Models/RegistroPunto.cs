using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class RegistroPunto
{
    public int IdRegistro { get; set; }

    public int IdCliente { get; set; }

    public DateTime FechaRegistro { get; set; }

    public int PuntosObtenidos { get; set; }

    //public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
