using PROMCOSER_API___Rol__Ubigeo.Core.DTO;

namespace PROMCOSER_API___Rol__Ubigeo.Core.Interfaces
{
    public interface IUbigeoService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<UbigeoDTO>> GetAllUbigeo();
        Task<UbigeoDTO> GetUbigeoById(int id);
        Task<int> Insert(UbigeoDTO ubigeoDTO);
        Task<bool> Update(UbigeoDTO ubigeoDTO);
    }
}