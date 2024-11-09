using PROMCOSER_API___Rol__Ubigeo.Core.DTO;

namespace PROMCOSER_API___Rol__Ubigeo.Core.Interfaces
{
    public interface IRolService
    {
        Task<bool> Delete(int id);
        Task<RolDTO> GetRolById(int id);
        Task<IEnumerable<RolDTO>> GetRoles();
        Task<int> Insert(RolDTO rolDTO);
        Task<bool> Update(RolDTO rolDTO);
    }
}