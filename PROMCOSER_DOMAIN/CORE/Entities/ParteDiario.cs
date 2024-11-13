using System;
using System.Collections.Generic;

namespace PROMCOSER_DOMAIN.CORE.Entities;

public partial class ParteDiario
{
    public int IdParteDiario { get; set; }

    public string? Serie { get; set; }

    public DateTime? Fecha { get; set; }

    public bool? Firmas { get; set; }

    public decimal? HorometroInicio { get; set; }

    public decimal? HorometroFinal { get; set; }

    public int? IdCliente { get; set; }

    public int? IdPersonal { get; set; }

    public int? IdMaquinaria { get; set; }

    public string? LugarTrabajo { get; set; }

    public decimal? Petroleo { get; set; }

    public decimal? Aceite { get; set; }

    public DateTime? ProximoMantenimiento { get; set; }

    public virtual ICollection<DetalleParteDiario> DetalleParteDiario { get; set; } = new List<DetalleParteDiario>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Maquinaria? IdMaquinariaNavigation { get; set; }

    public virtual Personal? IdPersonalNavigation { get; set; }
}
