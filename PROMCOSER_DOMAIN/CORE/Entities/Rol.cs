using System;
using System.Collections.Generic;

namespace PROMCOSER_DOMAIN.CORE.Entities;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Personal> Personal { get; set; } = new List<Personal>();
}
