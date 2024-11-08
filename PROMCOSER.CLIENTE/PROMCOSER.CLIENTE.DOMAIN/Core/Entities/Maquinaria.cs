using System;
using System.Collections.Generic;

namespace PROMCOSER.CLIENTE.DOMAIN.Core.Entities;

public partial class Maquinaria
{
    public long IdMaquinaria { get; set; }

    public string? Placa { get; set; }

    public string? Modelo { get; set; }

    public string? Marca { get; set; }

    public short? AnioCompra { get; set; }

    public TimeOnly? HorometroCompra { get; set; }

    public TimeOnly? HorometroActual { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<ParteDiario> ParteDiario { get; set; } = new List<ParteDiario>();
}
