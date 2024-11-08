using PROMCOSER_DOMAIN.Core.Entities;

namespace PROMCOSER_DOMAIN.Core.Interfaces
{
    public interface IDetalleParteDiarioRepository
    {
        Task<bool> Delete(long id);
        Task<DetalleParteDiario> GetDetalleById(long id);
        Task<IEnumerable<DetalleParteDiario>> GetDetalles();
        Task<IEnumerable<DetalleParteDiario>> GetDetallesByParteDiarioId(long parteDiarioId);
        Task<long> Insert(DetalleParteDiario detalleParteDiario);
        Task<bool> Update(DetalleParteDiario detalleParteDiario);
    }
}