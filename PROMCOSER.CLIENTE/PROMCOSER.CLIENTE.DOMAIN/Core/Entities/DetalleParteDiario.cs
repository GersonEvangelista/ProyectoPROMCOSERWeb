using System;
using System.Collections.Generic;

namespace PROMCOSER.CLIENTE.DOMAIN.Core.Entities;

public partial class DetalleParteDiario
{
    public long IdDetalleParteDiario { get; set; }

    public long? ParteDiarioId { get; set; }

    public int? Horas { get; set; }

    public string? TrabajoEfectuado { get; set; }

    public string? Descripcion { get; set; }

    public virtual ParteDiario? ParteDiario { get; set; }
}
