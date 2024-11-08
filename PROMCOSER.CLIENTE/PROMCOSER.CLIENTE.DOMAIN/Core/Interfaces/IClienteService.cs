using PROMCOSER.CLIENTE.DOMAIN.Core.DTO;

namespace PROMCOSER.CLIENTE.DOMAIN.Core.Interfaces
{
    public interface IClienteService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ClienteDTO>> GetClientes();
        Task<ClienteDTO> GetClienteyById(int id);
        Task<int> Insert(ClienteDTO1 clienteDTO);
        Task<bool> Update(ClienteDTO clienteDTO);
    }
}