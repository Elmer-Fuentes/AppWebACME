using System;
using System.Collections.Generic;

namespace AppWebACME.Models;

public partial class Requisicion
{
    public int Idrequisicion { get; set; }

    public int Idempresa { get; set; }

    public string NroRequiscion { get; set; } = null!;

    public DateOnly FechaEmision { get; set; }

    public bool Aprobada { get; set; }

    public bool Activo { get; set; }

    public virtual Empresa IdempresaNavigation { get; set; } = null!;

    public virtual ICollection<RequisicionAnotacion> RequisicionAnotacions { get; set; } = new List<RequisicionAnotacion>();

    public virtual ICollection<RequisicionDetalle> RequisicionDetalles { get; set; } = new List<RequisicionDetalle>();
}
