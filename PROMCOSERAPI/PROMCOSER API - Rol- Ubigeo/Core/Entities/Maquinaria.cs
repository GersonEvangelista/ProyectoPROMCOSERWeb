using System;
using System.Collections.Generic;

namespace PROMCOSER_API___Rol__Ubigeo.Core.Entities;

public partial class Maquinaria
{
    public int IdMaquinaria { get; set; }

    public string? Placa { get; set; }

    public string? Modelo { get; set; }

    public string? Marca { get; set; }

    public int? AnioCompra { get; set; }

    public int? HorometroCompra { get; set; }

    public int? HorometroActual { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<ParteDiario> ParteDiario { get; set; } = new List<ParteDiario>();
}
