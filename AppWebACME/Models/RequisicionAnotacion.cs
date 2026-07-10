using System;
using System.Collections.Generic;

namespace AppWebACME.Models;

public partial class RequisicionAnotacion
{
    public int IdrequisicionAnotacion { get; set; }

    public int Idrequisicion { get; set; }

    public string Anotacion { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual Requisicion IdrequisicionNavigation { get; set; } = null!;
}
