using PROMCOSER_DOMAIN.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROMCOSER_DOMAIN.CORE.DTO
{
    public class PersonalDTO
    {
        public class UserAuthDTO
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        public class UserRequestAuthDTO
        {
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
        }

        //ARON
        public class PersonalDTOfrontEnd
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

        }

        public class PersonalDTOfrontEnd2
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
        }


    }
}
