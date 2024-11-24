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
        private readonly IJWTService _jWTService; //PARA TOKEN

        public PersonalService(IPersonalRepository personalRepository, IJWTService jWTService)
        {
            _personalRepository = personalRepository;
            _jWTService = jWTService; //PARA TOKEN
        }
        public async Task<UserToken> SignIn(string username, string password)
        {
            var user = await _personalRepository.SignIn(username, password);
            if (user == null) return null;

            var token = _jWTService.GenerateJWToken(user);

            var userDTO = new UserToken()
            {
                Token = token,
                IdRol = user.IdRol
            };
            
            return userDTO;
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

        public async Task<IEnumerable<Personal>> GetOperadores()
        {
            return await _personalRepository.GetOperadores();
        }
        //ARON
        public async Task<IEnumerable<PersonalDTOfrontEnd>> GetPersonal()
        {
            var personals = await _personalRepository.GetPersonal();
            var personaslDTO = new List<PersonalDTOfrontEnd>();
            foreach (var personal in personals)
            {
                var personalDTO = new PersonalDTOfrontEnd();
                personalDTO.IdPersonal = personal.IdPersonal;
                personalDTO.Nombre = personal.Nombre;
                personalDTO.Apellido = personal.Apellido;
                personalDTO.IdRol = personal.IdRol;
                personalDTO.Telefono = personal.Telefono;
                personalDTO.Correo = personal.Correo;
                personalDTO.Dni = personal.Dni;
                personalDTO.Estado = personal.Estado;
                personalDTO.FechNacimiento = personal.FechNacimiento;
                personaslDTO.Add(personalDTO);
            }

            return personaslDTO;
        }

        public async Task<IEnumerable<PersonalDTOfrontEnd2>> GetPersonalDialog()
        {
            var personals = await _personalRepository.GetPersonal();
            var personaslDTO = new List<PersonalDTOfrontEnd2>();
            foreach (var personal in personals)
            {
                var personalDTO = new PersonalDTOfrontEnd2();
                personalDTO.IdPersonal = personal.IdPersonal;
                personalDTO.Nombre = personal.Nombre;
                personalDTO.Apellido = personal.Apellido;
                personalDTO.IdRol = personal.IdRol;
                personalDTO.Telefono = personal.Telefono;
                personalDTO.Correo = personal.Correo;
                personalDTO.Dni = personal.Dni;
                personalDTO.Estado = personal.Estado;
                personalDTO.FechNacimiento = personal.FechNacimiento;
                personalDTO.IdUbigeo = personal.IdUbigeo;
                personalDTO.Username = personal.Username;
                personalDTO.Password = personal.Password;
                personaslDTO.Add(personalDTO);
            }

            return personaslDTO;
        }

        public async Task<PersonalDTOfrontEnd2> GetPersonalyById(int id)
        {
            var personal = await _personalRepository.GetPersonalById(id);
            if (personal == null)
            {
                return null;
            }

            var personalDTO = new PersonalDTOfrontEnd2
            {
                IdPersonal = personal.IdPersonal,
                Nombre = personal.Nombre,
                Apellido = personal.Apellido,
                IdRol = personal.IdRol,
                Telefono = personal.Telefono,
                Correo = personal.Correo,
                Dni = personal.Dni,
                Estado = personal.Estado,
                FechNacimiento = personal.FechNacimiento,
                IdUbigeo = personal.IdUbigeo,
                Username = personal.Username,
                Password = personal.Password
            };

            return personalDTO;

        }

        public async Task<int> Insert(PersonalDTOfrontEnd2 personalDTO)
        {
            var personal = new Personal();
            personal.IdPersonal = personalDTO.IdPersonal;
            personal.Nombre = personalDTO.Nombre;
            personal.Apellido = personalDTO.Apellido;
            personal.IdRol = personalDTO.IdRol;
            personal.Telefono = personalDTO.Telefono;
            personal.Correo = personalDTO.Correo;
            personal.Dni = personalDTO.Dni;
            personal.Estado = personalDTO.Estado;
            personal.FechNacimiento = personalDTO.FechNacimiento;
            personal.IdUbigeo = personalDTO.IdUbigeo;
            personal.Username = personalDTO.Username;
            personal.Password = personalDTO.Password;

            int id = await _personalRepository.Insert(personal);
            return id;
        }

        public async Task<bool> Update(PersonalDTOfrontEnd2 personalDTO)
        {
            var personal = new Personal();
            personal.IdPersonal = personalDTO.IdPersonal;
            personal.Nombre = personalDTO.Nombre;
            personal.Apellido = personalDTO.Apellido;
            personal.IdRol = personalDTO.IdRol;
            personal.Telefono = personalDTO.Telefono;
            personal.Correo = personalDTO.Correo;
            personal.Dni = personalDTO.Dni;
            personal.Estado = personalDTO.Estado;
            personal.FechNacimiento = personalDTO.FechNacimiento;
            personal.IdUbigeo = personalDTO.IdUbigeo;
            personal.Username = personalDTO.Username;
            personal.Password = personalDTO.Password;

            bool resp = await _personalRepository.Update(personal);
            return resp;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _personalRepository.Delete(id);
            return result;
        }

    }
}



