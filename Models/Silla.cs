﻿namespace WebApi.Models;

public partial class Silla
{
    public int? IdMultiplex { get; set; }

    public int? NumSala { get; set; }

    public string? NumSilla { get; set; }

    public string? TipoSilla { get; set; }

    //public virtual ICollection<Boleta> Boleta { get; set; } = new List<Boleta>();

    //public virtual Sala Sala { get; set; } = null;

    //public virtual TipoSilla TipoSillaNavigation { get; set; } = null;
}
