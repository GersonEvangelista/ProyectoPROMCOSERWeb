using System;
using System.Collections.Generic;

namespace PROMCOSER.CLIENTE.DOMAIN.Core.Entities;

public partial class Ubigeo
{
    public long IdUbigeo { get; set; }

    public string Departamento { get; set; } = null!;

    public string Provincia { get; set; } = null!;

    public string Distrito { get; set; } = null!;

    public virtual ICollection<Personal> Personal { get; set; } = new List<Personal>();
}
