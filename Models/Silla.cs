﻿using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Silla
{
    public int IdMultiplex { get; set; }

    public int NumSala { get; set; }

    public string NumSilla { get; set; } = null!;

    public string TipoSilla { get; set; } = null!;

    public virtual ICollection<Boletum> Boleta { get; set; } = new List<Boletum>();

    public virtual Sala Sala { get; set; } = null!;

    public virtual TipoSilla TipoSillaNavigation { get; set; } = null!;
}
