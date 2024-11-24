using Microsoft.AspNetCore.Mvc;
using PROMCOSER_DOMAIN.CORE.DTO;
using PROMCOSER_DOMAIN.CORE.Entities;

namespace PROMCOSER_DOMAIN.CORE.Interfaces
{
    public interface IDetalleParteDiarioRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DetalleParteDiario>> GetDetalleParteDiario();
        Task<DetalleParteDiario> GetDetalleParteDiarioById(int id);
        Task<bool> Insert(DetalleParteDiario detalleparteDiario);
        Task<bool> Update(int id, DetalleParteDiario detalleparteDiario);
    }
}