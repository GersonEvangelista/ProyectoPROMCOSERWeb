using System;
using System.Collections.Generic;

namespace PROMCOSER_API___Rol__Ubigeo.Core.Entities;

public partial class Personal
{
    public int IdPersonal { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? RolId { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Dni { get; set; }

    public int? Estado { get; set; }

    public DateOnly? Fechnacimiento { get; set; }

    public int? UbigeoId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<ParteDiario> ParteDiario { get; set; } = new List<ParteDiario>();

    public virtual Rol? Rol { get; set; }

    public virtual Ubigeo? Ubigeo { get; set; }
}
