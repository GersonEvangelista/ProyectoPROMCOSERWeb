using Microsoft.EntityFrameworkCore;
using PROMCOSER_API___Rol__Ubigeo.Core.Entities;
using PROMCOSER_API___Rol__Ubigeo.Core.Interfaces;
using PROMCOSER_API___Rol__Ubigeo.Infraestructure.Data;

namespace PROMCOSER_API___Rol__Ubigeo.Infraestructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly PromcoserContext _promcoserContext;
        public RolRepository(PromcoserContext promcoserContext)
        {
            _promcoserContext = promcoserContext;

        }

        public async Task<IEnumerable<Rol>> GetRoles()
        {
            var roles = await _promcoserContext.Rol.Where(c => c.IdRol != 0).ToListAsync();
            return roles;
        }

        //Get Roles by ID
        public async Task<Rol> GetRolById(int id)
        {
            var rol = await _promcoserContext
                    .Rol
                    .Where(r => r.IdRol == id)
                    .FirstOrDefaultAsync();
            return rol;
        }

        //Create Rol
        public async Task<int> Insert(Rol rol)
        {
            _promcoserContext.Rol.AddAsync(rol);
            await _promcoserContext.SaveChangesAsync();
            return rol.IdRol;
        }

        //Update Rol
        public async Task<bool> UpdateRol(Rol rol)
        {
            _promcoserContext.Rol.Update(rol);
            return await _promcoserContext.SaveChangesAsync() > 0;
        }

        //Delete Rol
        public async Task<bool> DeleteRol(int idRol)
        {
            var rol = await _promcoserContext.Rol
                .FirstOrDefaultAsync(r => r.IdRol == idRol);
            if (rol == null) return false;
            _promcoserContext.Rol.Remove(rol);
            int rows = await _promcoserContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
