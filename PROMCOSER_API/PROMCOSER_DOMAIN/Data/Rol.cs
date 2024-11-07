using System;
using System.Collections.Generic;

namespace PROMCOSER_DOMAIN.Data;

public partial class Rol
{
    public long IdRol { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Personal> Personal { get; set; } = new List<Personal>();
}
