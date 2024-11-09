using Microsoft.EntityFrameworkCore;
using PROMCOSER_API___Rol__Ubigeo.Core.Entities;
using PROMCOSER_API___Rol__Ubigeo.Core.Interfaces;
using PROMCOSER_API___Rol__Ubigeo.Infraestructure.Data;
namespace PROMCOSER_API___Rol__Ubigeo.Infraestructure.Repositories
{
    public class UbigeoResository : IUbigeoRepository
    {
        private readonly PromcoserContext _promcoserContext;

        public UbigeoResository(PromcoserContext promcoserContext)
        {
            _promcoserContext = promcoserContext;
        }

        public async Task<IEnumerable<Ubigeo>> GetUbigeo()
        {
            var ubigeo = await _promcoserContext.Ubigeo.Where(u => u.IdUbigeo != null).ToListAsync();
            return ubigeo;
        }

        //Get Ubigeo by ID
        public async Task<Ubigeo> GetUbigeoById(int id)
        {
            var ubigeo = await _promcoserContext
                    .Ubigeo
                    .Where(c => c.IdUbigeo == id)
                    .FirstOrDefaultAsync();
            return ubigeo;
        }

        //Create Ubigeo
        public async Task<int> Insert(Ubigeo ubigeo)
        {
            _promcoserContext.Ubigeo.AddAsync(ubigeo);
            await _promcoserContext.SaveChangesAsync();
            return ubigeo.IdUbigeo;
        }

        //Update ubigeo
        public async Task<bool> Update(Ubigeo ubigeo)
        {
            _promcoserContext.Ubigeo.Update(ubigeo);
            int rows = await _promcoserContext.SaveChangesAsync();
            return rows > 0;
        }

        //Delete ubigeo
        public async Task<bool> Delete(int id)
        {
            var ubigeo = await _promcoserContext.Ubigeo.FindAsync(id);

            if (ubigeo == null)
            {
                return false;
            }


            _promcoserContext.Ubigeo.Remove(ubigeo);
            await _promcoserContext.SaveChangesAsync();

            return true;
        }
    }
}
