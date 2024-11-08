using PROMCOSER_DOMAIN.Core.DTO;

namespace PROMCOSER_DOMAIN.Core.Interfaces
{
    public interface IDetalleParteDiarioService
    {
        Task<bool> Delete(long id);
        Task<DetalleParteDiarioDTO> GetDetalleById(long id);
        Task<IEnumerable<DetalleParteDiarioListDTO>> GetDetalles();
        Task<IEnumerable<DetalleParteDiarioListDTO>> GetDetallesByParteDiarioId(long parteDiarioId);
        Task<long> Insert(DetalleParteDiarioDTO detalleParteDiarioDTO);
        Task<bool> Update(DetalleParteDiarioDTO detalleParteDiarioDTO);
    }
}