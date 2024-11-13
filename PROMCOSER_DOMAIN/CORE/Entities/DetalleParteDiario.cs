using System;
using System.Collections.Generic;

namespace PROMCOSER_DOMAIN.CORE.Entities;

public partial class DetalleParteDiario
{
    public int IdDetalleParteDiario { get; set; }

    public int? IdParteDiario { get; set; }

    public int? Horas { get; set; }

    public string? TrabajoEfectuado { get; set; }

    public string? Descripcion { get; set; }

    public virtual ParteDiario? IdParteDiarioNavigation { get; set; }
}
