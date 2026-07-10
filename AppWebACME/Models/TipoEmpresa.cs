using System;
using System.Collections.Generic;

namespace AppWebACME.Models;

public partial class TipoEmpresa
{
    public int IdtipoEmpresa { get; set; }

    public string TipoEmpresa1 { get; set; } = null!;

    public string Descripción { get; set; } = null!;

    public string? Sigla { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
