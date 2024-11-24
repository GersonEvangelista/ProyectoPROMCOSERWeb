using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROMCOSER_DOMAIN.CORE.DTO
{
    public class ParteDiarioDTO
    {
        public int IdParteDiario { get; set; }
        public DateTime Fecha { get; set; }
        public bool Firmas { get; set; }
        public decimal HorometroInicio { get; set; }
        public decimal HorometroFinal { get; set; }
        public int IdCliente { get; set; }
        public int IdPersonal { get; set; }
        public int IdMaquinaria { get; set; }
        public string LugarTrabajo { get; set; }
        public decimal Petroleo { get; set; }
        public decimal Aceite { get; set; }
        public DateTime ProximoMantenimiento { get; set; }
    }

}
