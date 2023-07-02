using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Sala
{
    public int IdMultiplex { get; set; }

    public int NumSala { get; set; }

    public int? NumSillasGeneral { get; set; }

    public int? NumSillasPreferencial { get; set; }

    //public virtual ICollection<Funcion> Funcions { get; set; } = new List<Funcion>();

    //[BindNever]
    //public virtual Multiplex IdMultiplexNavigation { get; set; } = null!;

    //public virtual ICollection<Silla> Sillas { get; set; } = new List<Silla>();
}
