﻿using System;
using System.Collections.Generic;

namespace PROMCOSER_DOMAIN.Core.Entities;

public partial class Cliente
{
    public long IdCliente { get; set; }

    public string? TipoCliente { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Estado { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Dni { get; set; }

    public string? RazonSocial { get; set; }

    public string? Ruc { get; set; }

    public virtual ICollection<ParteDiario> ParteDiario { get; set; } = new List<ParteDiario>();
}