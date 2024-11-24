using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROMCOSER_DOMAIN.CORE.DTO
{
    public class DetalleParteDiarioDTO
    {
        public int Horas { get; set; }

        public string TrabajoEfectuado { get; set; }

        public string Descripcion { get; set; }
    }

    public class DetalleParteDiarioDTO2
    {
        public int Horas { get; set; }
        public string TrabajoEfectuado { get; set; }
        public string Descripcion { get; set; }
        public int IdParteDiario { get; set; } // Este campo es requerido
    }

}
