using PROMCOSER_DOMAIN.CORE.Entities;

namespace PROMCOSER_DOMAIN.CORE.Interfaces
{
    public interface IParteDiarioRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ParteDiario>> GetParteDiario();
        Task<ParteDiario> GetParteDiarioById(int id);
        Task<bool> Insert(ParteDiario parteDiario);
        Task<ParteDiario> Insert2(ParteDiario parteDiario);
        Task<bool> LogicalDelete(int id);
        Task<bool> Update(int id, ParteDiario parteDiario);
    }
}