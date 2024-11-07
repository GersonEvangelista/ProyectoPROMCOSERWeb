using PROMCOSER_DOMAIN.Data;

namespace PROMCOSER_DOMAIN.Core.Interfaces
{
    public interface IParteDiarioRepository
    {
        Task<bool> Delete(int id);
        Task<ParteDiario> GetParteDiarioById(int id);
        Task<IEnumerable<ParteDiario>> GetParteDiarios();
        Task Insert(ParteDiario parteDiario);
        Task<bool> Update(ParteDiario parteDiario);
    }
}