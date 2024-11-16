using System;
using System.Collections.Generic;

namespace PROMCOSER_DOMAIN.CORE.Entities;

public partial class Maquinaria
{
    public int IdMaquinaria { get; set; }

    public string? Placa { get; set; }

    public string? Modelo { get; set; }

    public string? Marca { get; set; }

    public int AnioCompra { get; set; }

    public decimal HorometroCompra { get; set; }

    public decimal HorometroActual { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<ParteDiario> ParteDiario { get; set; } = new List<ParteDiario>();
}
