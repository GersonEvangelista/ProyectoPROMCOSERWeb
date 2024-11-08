using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROMCOSER_DOMAIN.Core.DTO
{
    public class MaquinariaDTO
    {
        public int IdMaquinaria { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public DateOnly AnioCompra { get; set; }
        public int HorometroCompra { get; set; }
        public int HorometroActual { get; set; }
        public bool Estado { get; set; }
    }
}
