using PROMCOSER_DOMAIN.CORE.Entities;

namespace PROMCOSER_DOMAIN.CORE.Interfaces
{
    public interface IMaquinariaRepository
    {
        Task<bool> Delete(int id);
        Task<Maquinaria> GetMaquinariaById(int id);
        Task<Maquinaria> GetMaquinariaByPlaca(string placa);
        Task<IEnumerable<Maquinaria>> GetMaquinarias();
        Task<IEnumerable<Maquinaria>> GetMaquinariasByMarca(string marca);
        Task<IEnumerable<Maquinaria>> GetMaquinariasByModelo(string modelo);
        Task<bool> Insert(Maquinaria maquinaria);
        Task<bool> LogicalDelete(int id);
        Task<bool> Update(int id, Maquinaria maquinaria);
    }
}