using PROMCOSER_API___Rol__Ubigeo.Core.Entities;

namespace PROMCOSER_API___Rol__Ubigeo.Core.Interfaces
{
    public interface IRolRepository
    {
        Task<bool> DeleteRol(int idRol);
        Task<Rol> GetRolById(int id);
        Task<IEnumerable<Rol>> GetRoles();
        Task<int> Insert(Rol rol);
        Task<bool> UpdateRol(Rol rol);
    }
}