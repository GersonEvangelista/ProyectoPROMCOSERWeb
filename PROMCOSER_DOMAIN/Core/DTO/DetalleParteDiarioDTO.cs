using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROMCOSER_DOMAIN.Core.DTO
{
    public class DetalleParteDiarioDTO
    {
        public long IdDetalleParteDiario { get; set; }
        public long ParteDiarioId { get; set; }
        public int Horas { get; set; }
        public string? TrabajoEfectuado { get; set; }
        public string? Descripcion { get; set; }
    }

    public class DetalleParteDiarioListDTO
    {
        public long IdDetalleParteDiario { get; set; }
        public string? TrabajoEfectuado { get; set; }
    }
}
