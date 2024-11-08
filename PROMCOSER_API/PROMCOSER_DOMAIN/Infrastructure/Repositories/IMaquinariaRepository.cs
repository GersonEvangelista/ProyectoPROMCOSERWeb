using PROMCOSER_DOMAIN.Core.Entities;

namespace PROMCOSER_DOMAIN.Infrastructure.Repositories
{
    public interface IMaquinariaRepository
    {
        Task<bool> Delete(int id);
        Task<Maquinaria> GetMaquinariaById(int id);
        Task<Maquinaria> GetMaquinariaByMarca(string marca);
        Task<Maquinaria> GetMaquinariaByModelo(string modelo);
        Task<Maquinaria> GetMaquinariaByPlaca(string placa);
        Task<IEnumerable<Maquinaria>> GetMaquinarias();
        Task<bool> Insert(Maquinaria maquinaria);
        Task<bool> LogicalDelete(int id);
        Task<bool> Update(Maquinaria maquinaria);
    }
}