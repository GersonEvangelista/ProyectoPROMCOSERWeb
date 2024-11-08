using PROMCOSER.CLIENTE.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROMCOSER.CLIENTE.DOMAIN.Core.DTO
{
    public class ClienteDTO
    {
        public long IdCliente { get; set; }
        public string? TipoCliente { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public int? Estado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Dni { get; set; }
        public string? RazonSocial { get; set; }
        public string? Ruc { get; set; }
        public virtual ICollection<ParteDiario> ParteDiario { get; set; } = new List<ParteDiario>();
    }

    public class ClienteDTO1
    {
        public long IdCliente { get; set; }
        public string? TipoCliente { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public int? Estado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Dni { get; set; }
        public string? RazonSocial { get; set; }
        public string? Ruc { get; set; }
    }
    public class ClienteEmpresaDTO
    {
        public long IdCliente { get; set; }
        public string? TipoCliente { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public int? Estado { get; set; }
        public string? RazonSocial { get; set; }
        public string? Ruc { get; set; }
    }

}
