using PROMCOSER_API___Rol__Ubigeo.Core.DTO;
using PROMCOSER_API___Rol__Ubigeo.Core.Entities;
using PROMCOSER_API___Rol__Ubigeo.Core.Interfaces;

namespace PROMCOSER_API___Rol__Ubigeo.Core.Services
{
    public class UbigeoService : IUbigeoService
    {
        private readonly IUbigeoRepository _ubigeoRepository;

        public UbigeoService(IUbigeoRepository ubigeoRepository)
        {
            _ubigeoRepository = ubigeoRepository;
        }

        public async Task<IEnumerable<UbigeoDTO>> GetAllUbigeo()
        {
            var ubigeo = await _ubigeoRepository.GetUbigeo();
            return ubigeo.Select(x => new UbigeoDTO
            {
                IdUbigeo = x.IdUbigeo,
                Departamento = x.Departamento,
                Provincia = x.Provincia,
                Distrito = x.Distrito,
            }).ToList();
        }

        public async Task<UbigeoDTO> GetUbigeoById(int id)
        {
            var ubigeo = await _ubigeoRepository.GetUbigeoById(id);
            if (ubigeo == null)
            {
                return null;
            }

            var ubigeoDTO = new UbigeoDTO
            {
                IdUbigeo = ubigeo.IdUbigeo,
                Departamento = ubigeo.Departamento,
                Provincia = ubigeo.Provincia,
                Distrito = ubigeo.Distrito,
            };

            return ubigeoDTO;

        }
        public async Task<int> Insert(UbigeoDTO ubigeoDTO)
        {
            var ubigeo = new Ubigeo();
            ubigeo.Departamento = ubigeoDTO.Departamento;
            ubigeo.Provincia = ubigeoDTO.Provincia;
            ubigeo.Distrito = ubigeoDTO.Distrito;
            int id = await _ubigeoRepository.Insert(ubigeo);
            return id;

        }
        public async Task<bool> Delete(int id)
        {
            var ubigeo = await _ubigeoRepository.Delete(id);
            return ubigeo;
        }

        public async Task<bool> Update(UbigeoDTO ubigeoDTO)
        {

            var ubigeo = new Ubigeo();
            ubigeo.IdUbigeo = ubigeoDTO.IdUbigeo;
            ubigeo.Departamento = ubigeoDTO.Departamento;
            ubigeo.Provincia = ubigeoDTO.Provincia;
            ubigeo.Distrito = ubigeoDTO.Distrito;
            bool r = await _ubigeoRepository.Update(ubigeo);
            return r;
        }
    }


}
