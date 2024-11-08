using PROMCOSER.CLIENTE.DOMAIN.Core.Entities;

namespace PROMCOSER.CLIENTE.DOMAIN.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Cliente>> GetCliente();
        Task<Cliente> GetClienteById(int id);
        Task<int> Insert(Cliente cliente);
        Task<bool> Update(Cliente cliente);
    }
}