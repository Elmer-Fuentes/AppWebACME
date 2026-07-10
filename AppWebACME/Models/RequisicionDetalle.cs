using System;
using System.Collections.Generic;

namespace AppWebACME.Models;

public partial class RequisicionDetalle
{
    public int IdrequisicionDetalle { get; set; }

    public int Idrequisicion { get; set; }

    public int Idarticulo { get; set; }

    public short Linea { get; set; }

    public decimal Cantidad { get; set; }

    public bool Activo { get; set; }

    public virtual Articulo IdarticuloNavigation { get; set; } = null!;

    public virtual Requisicion IdrequisicionNavigation { get; set; } = null!;
}
