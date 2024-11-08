using System;
using System.Collections.Generic;

namespace PROMCOSER.CLIENTE.DOMAIN.Core.Entities;

public partial class ParteDiario
{
    public long IdParteDiario { get; set; }

    public string? Serie { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Firmas { get; set; }

    public TimeOnly? HorometroInicio { get; set; }

    public TimeOnly? HorometroFinal { get; set; }

    public long? ClienteId { get; set; }

    public long? PersonalId { get; set; }

    public long? MaquinariaId { get; set; }

    public string? LugarTrabajo { get; set; }

    public decimal? Petroleo { get; set; }

    public decimal? Aceite { get; set; }

    public DateOnly? ProximoMantenimiento { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetalleParteDiario> DetalleParteDiario { get; set; } = new List<DetalleParteDiario>();

    public virtual Maquinaria? Maquinaria { get; set; }

    public virtual Personal? Personal { get; set; }
}
