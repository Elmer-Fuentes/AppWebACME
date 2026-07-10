using System;
using System.Collections.Generic;

namespace AppWebACME.Models;

public partial class Empresa
{
    public int Idempresa { get; set; }

    public int IdtipoEmpresa { get; set; }

    public string Empresa1 { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public DateOnly FechaCreacion { get; set; }

    public decimal Presupuesto { get; set; }

    public bool Activo { get; set; }

    public virtual TipoEmpresa IdtipoEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<Requisicion> Requisicions { get; set; } = new List<Requisicion>();
}
