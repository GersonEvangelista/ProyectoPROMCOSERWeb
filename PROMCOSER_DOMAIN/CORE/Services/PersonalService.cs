using PROMCOSER_DOMAIN.CORE.DTO;
using PROMCOSER_DOMAIN.CORE.Entities;
using PROMCOSER_DOMAIN.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PROMCOSER_DOMAIN.CORE.DTO.PersonalDTO;

namespace PROMCOSER_DOMAIN.CORE.Services
{
    public class PersonalService : IPersonalService
    {
        private readonly IPersonalRepository _personalRepository;

        public PersonalService(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }
        public async Task<Personal> SignIn(string username, string password)
        {
            var user = await _personalRepository.SignIn(username, password);
            if (user == null) return null;

            /*
            //var token = _jwtService.GenerateJWToken(user);
            var estado = true;
            var userDTO = new UserRequestAuthDTO()
            {
                //Username = username,
                //Password = password,
                //Token = token,
                Estado = estado
            };
            */
            return user;
        }

        public async Task<bool> SignUp(UserRequestAuthDTO userDTO)
        {
            var user = new Personal();
            user.Nombre = userDTO.Nombre;
            user.Apellido = userDTO.Apellido;
            user.IdRol = userDTO.IdRol;
            user.Telefono = userDTO.Telefono;
            user.Correo = userDTO.Correo;
            user.Dni = userDTO.Dni;
            user.Estado = userDTO.Estado;
            user.FechNacimiento = userDTO.FechNacimiento;
            user.IdUbigeo = userDTO.IdUbigeo;
            user.Username = userDTO.Username;
            user.Password = userDTO.Password;
            return await _personalRepository.SignUp(user);
        }

    }
}



