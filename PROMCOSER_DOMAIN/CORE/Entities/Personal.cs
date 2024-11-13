using System;
using System.Collections.Generic;

namespace PROMCOSER_DOMAIN.CORE.Entities;

public partial class Personal
{
    public int IdPersonal { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? IdRol { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Dni { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechNacimiento { get; set; }

    public int? IdUbigeo { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual Ubigeo? IdUbigeoNavigation { get; set; }

    public virtual ICollection<ParteDiario> ParteDiario { get; set; } = new List<ParteDiario>();
}
