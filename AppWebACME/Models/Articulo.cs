using System;
using System.Collections.Generic;

namespace AppWebACME.Models;

public partial class Articulo
{
    public int Idarticulo { get; set; }

    public int IdunidadMedida { get; set; }

    public string Articulo1 { get; set; } = null!;

    public decimal Precio { get; set; }

    public decimal StockActual { get; set; }

    public bool Activo { get; set; }

    public virtual UnidadMedidum IdunidadMedidaNavigation { get; set; } = null!;

    public virtual ICollection<RequisicionDetalle> RequisicionDetalles { get; set; } = new List<RequisicionDetalle>();
}
