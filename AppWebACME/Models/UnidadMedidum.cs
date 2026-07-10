using System;
using System.Collections.Generic;

namespace AppWebACME.Models;

public partial class UnidadMedidum
{
    public int IdunidadMedida { get; set; }

    public string UnidadMedida { get; set; } = null!;

    public string Sigla { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
}
