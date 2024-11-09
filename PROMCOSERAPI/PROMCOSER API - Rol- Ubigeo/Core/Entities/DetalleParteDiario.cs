using System;
using System.Collections.Generic;

namespace PROMCOSER_API___Rol__Ubigeo.Core.Entities;

public partial class DetalleParteDiario
{
    public int IdDetalleParteDiario { get; set; }

    public int? ParteDiarioId { get; set; }

    public int? Horas { get; set; }

    public string? TrabajoEfectuado { get; set; }

    public string? Descripcion { get; set; }

    public virtual ParteDiario? ParteDiario { get; set; }
}
