﻿using PROMCOSER_DOMAIN.CORE.DTO;
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
        public async Task<UserAuthDTO> SignIn(string username, string password)
        {
            var user = await _personalRepository.SignIn(username, password);
            if (user == null) return null;


            //var token = _jwtService.GenerateJWToken(user);
            //var sendEmail = false;
            var userDTO = new UserAuthDTO()
            {
                Username = username,
                Password = password,
                //Token = token,
                //IsEmailSent = sendEmail
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
            return await _personalRepository.SignUp(user);
        }

    }
}


