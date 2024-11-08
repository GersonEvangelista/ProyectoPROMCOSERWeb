using PROMCOSER.CLIENTE.DOMAIN.Core.DTO;
using PROMCOSER.CLIENTE.DOMAIN.Core.Entities;
using PROMCOSER.CLIENTE.DOMAIN.Core.Interfaces;
using PROMCOSER.CLIENTE.DOMAIN.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PROMCOSER.CLIENTE.DOMAIN.Core.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientes()
        {
            var clientes = await _clienteRepository.GetCliente();
            var clientesDTO = new List<ClienteDTO>();
            foreach (var cliente in clientes)
            {
                var clienteDTO = new ClienteDTO();
                clienteDTO.IdCliente = cliente.IdCliente;
                clienteDTO.TipoCliente = cliente.TipoCliente;
                clienteDTO.Telefono = cliente.Telefono;
                clienteDTO.Correo = cliente.Correo;
                clienteDTO.Direccion = cliente.Direccion;
                clienteDTO.Estado = cliente.Estado;
                clienteDTO.Nombre = cliente.Nombre;
                clienteDTO.Apellido = cliente.Apellido;
                clienteDTO.Dni = cliente.Dni;
                clienteDTO.RazonSocial = cliente.RazonSocial;
                clienteDTO.Ruc = cliente.Ruc;
                clientesDTO.Add(clienteDTO);
            }

            return clientesDTO;
        }

        public async Task<ClienteDTO> GetClienteyById(int id)
        {
            var cliente = await _clienteRepository.GetClienteById(id);
            if (cliente == null)
            {
                return null;
            }

            var clienteDTO = new ClienteDTO
            {
                IdCliente = cliente.IdCliente,
                TipoCliente = cliente.TipoCliente,
                Telefono = cliente.Telefono,
                Correo = cliente.Correo,
                Direccion = cliente.Direccion,
                Estado = cliente.Estado,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Dni = cliente.Dni,
                RazonSocial = cliente.RazonSocial,
                Ruc = cliente.Ruc,
            };

            return clienteDTO;

        }

        public async Task<int> Insert(ClienteDTO1 clienteDTO)
        {
            var cliente = new Cliente();
            cliente.TipoCliente = clienteDTO.TipoCliente;
            cliente.Telefono = clienteDTO.Telefono;
            cliente.Correo = clienteDTO.Correo;
            cliente.Direccion = clienteDTO.Direccion;
            cliente.Estado = clienteDTO.Estado;
            cliente.Nombre = clienteDTO.Nombre;
            cliente.Apellido = clienteDTO.Apellido;
            cliente.Dni = clienteDTO.Dni;
            cliente.RazonSocial = clienteDTO.RazonSocial;
            cliente.Ruc = clienteDTO.Ruc;

            int id = await _clienteRepository.Insert(cliente);
            return id;

        }

        public async Task<bool> Update(ClienteDTO clienteDTO)
        {

            var cliente = new Cliente();
            cliente.IdCliente = clienteDTO.IdCliente;
            cliente.TipoCliente = clienteDTO.TipoCliente;
            cliente.Telefono = clienteDTO.Telefono;
            cliente.Correo = clienteDTO.Correo;
            cliente.Direccion = clienteDTO.Direccion;
            cliente.Estado = clienteDTO.Estado;
            cliente.Nombre = clienteDTO.Nombre;
            cliente.Apellido = clienteDTO.Apellido;
            cliente.Dni = clienteDTO.Dni;
            cliente.RazonSocial = clienteDTO.RazonSocial;
            cliente.Ruc = clienteDTO.Ruc;
            bool resp = await _clienteRepository.Update(cliente);
            return resp;
        }

        public async Task<bool> Delete(int id)
        {
            var cli = await _clienteRepository.Delete(id);
            return cli;
        }








    }
}
