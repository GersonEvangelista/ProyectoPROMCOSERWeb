using PROMCOSER_API___Rol__Ubigeo.Core.DTO;
using PROMCOSER_API___Rol__Ubigeo.Core.Entities;
using PROMCOSER_API___Rol__Ubigeo.Core.Interfaces;

namespace PROMCOSER_API___Rol__Ubigeo.Core.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;
        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<IEnumerable<RolDTO>> GetRoles()
        {
            var roles = await _rolRepository.GetRoles();
            var rolesDTO = new List<RolDTO>();
            foreach (var rol in roles)
            {
                var rolDTO = new RolDTO();
                rolDTO.IdRol = rol.IdRol;
                rolDTO.Descripcion = rol.Descripcion;
                rolesDTO.Add(rolDTO);
            }

            return rolesDTO;
        }

        public async Task<RolDTO> GetRolById(int id)
        {
            var rol = await _rolRepository.GetRolById(id);
            if (rol == null)
            {
                return null;
            }

            var rolDTO = new RolDTO
            {
                IdRol = rol.IdRol,
                Descripcion = rol.Descripcion
            };

            return rolDTO;

        }

        public async Task<int> Insert(RolDTO rolDTO)
        {
            var rol = new Rol();
            rol.Descripcion = rolDTO.Descripcion;
            int id = await _rolRepository.Insert(rol);
            return id;

        }
        public async Task<bool> Delete(int id)
        {
            var d = await _rolRepository.DeleteRol(id);
            return d;
        }

        public async Task<bool> Update(RolDTO rolDTO)
        {

            var rol = new Rol();
            rol.IdRol = rolDTO.IdRol;
            rol.Descripcion = rolDTO.Descripcion;
            bool r = await _rolRepository.UpdateRol(rol);
            return r;
        }
    }

}
