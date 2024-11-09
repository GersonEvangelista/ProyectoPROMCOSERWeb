using PROMCOSER_API___Rol__Ubigeo.Core.Entities;

namespace PROMCOSER_API___Rol__Ubigeo.Core.Interfaces
{
    public interface IUbigeoRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Ubigeo>> GetUbigeo();
        Task<Ubigeo> GetUbigeoById(int id);
        Task<int> Insert(Ubigeo ubigeo);
        Task<bool> Update(Ubigeo ubigeo);
    }
}