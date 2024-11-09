using System;
using System.Collections.Generic;

namespace PROMCOSER_API___Rol__Ubigeo.Core.Entities;

public partial class ParteDiario
{
    public int IdParteDiario { get; set; }

    public string? Serie { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Firmas { get; set; }

    public int? HorometroInicio { get; set; }

    public int? HorometroFinal { get; set; }

    public int? ClienteId { get; set; }

    public int? PersonalId { get; set; }

    public int? MaquinariaId { get; set; }

    public string? LugarTrabajo { get; set; }

    public decimal? Petroleo { get; set; }

    public decimal? Aceite { get; set; }

    public DateOnly? ProximoMantenimiento { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetalleParteDiario> DetalleParteDiario { get; set; } = new List<DetalleParteDiario>();

    public virtual Maquinaria? Maquinaria { get; set; }

    public virtual Personal? Personal { get; set; }
}
