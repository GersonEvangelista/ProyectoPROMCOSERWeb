using Microsoft.EntityFrameworkCore;
using PROMCOSER.CLIENTE.DOMAIN.Core.Entities;
using PROMCOSER.CLIENTE.DOMAIN.Core.Interfaces;
using PROMCOSER.CLIENTE.DOMAIN.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROMCOSER.CLIENTE.DOMAIN.Infraestructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PromcoserContext _promcoserContext;

        public ClienteRepository(PromcoserContext promcoserContext)
        {
            _promcoserContext = promcoserContext;
        }

        public async Task<IEnumerable<Cliente>> GetCliente()
        {
            var clientes = await _promcoserContext.Cliente.Where(c => c.Estado == 1).ToListAsync();
            return clientes;
        }

        //Get Cliente by ID
        public async Task<Cliente> GetClienteById(int id)
        {
            var cliente = await _promcoserContext
                    .Cliente
                    .Where(c => c.IdCliente == id && c.Estado == 1)
                    .FirstOrDefaultAsync();
            return cliente;
        }

        //Create Cliente
        public async Task<int> Insert(Cliente cliente)
        {
            cliente.Estado = 1;
            await _promcoserContext.Cliente.AddAsync(cliente);
            int rows = await _promcoserContext.SaveChangesAsync();

            if (rows > 0)
            {
                return (int)cliente.IdCliente;
            }
            else
            {
                return -1;
            }

        }

        //Update cliente
        public async Task<bool> Update(Cliente cliente)
        {
            _promcoserContext.Cliente.Update(cliente);
            int rows = await _promcoserContext.SaveChangesAsync();
            return rows > 0;
        }

        //Delete cliente
        public async Task<bool> Delete(int id)
        {
            var cliente = await _promcoserContext
                            .Cliente
                            .FirstOrDefaultAsync(c => c.IdCliente == id);

            if (cliente == null) return false;

            cliente.Estado = 0;
            int rows = await _promcoserContext.SaveChangesAsync();
            return (rows > 0);
        }
    }
}
