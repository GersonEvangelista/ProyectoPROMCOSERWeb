using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.Core.Interfaces;
using PROMCOSER_DOMAIN.Data;

namespace PROMCOSER_DOMAIN.Infrastructure.Repositories
{
    public class ParteDiarioRepository : IParteDiarioRepository
    {

        private readonly PromcoserContext _PromcoserContext;

        public ParteDiarioRepository(PromcoserContext promcoserContext)
        {
            _PromcoserContext = promcoserContext;
        }




        public ParteDiarioRepository() { }





        public async Task<IEnumerable<ParteDiario>> GetParteDiarios()
        {

            return await _PromcoserContext.ParteDiario.ToListAsync();
        }

        /*public async Task<ParteDiario> GetParteDiarioById(int id)
        {
            var parteDiario = await _PromcoserContext.ParteDiario.FindAsync(id);
            if (parteDiario == null)
            {
                throw new Exception("ParteDiario not found");
            }
            return parteDiario;
        }*/




        //Obtener parte diario por ID
        public async Task<ParteDiario> GetParteDiarioById(int id)
        {
            return await _PromcoserContext.ParteDiario.FirstOrDefaultAsync(pd => pd.IdParteDiario == id);
        }



        //Insertar
        public async Task Insert(ParteDiario parteDiario)
        {
            await _PromcoserContext.ParteDiario.AddAsync(parteDiario);
            await _PromcoserContext.SaveChangesAsync();
        }



        //Actualizar parte diario

        public async Task<bool> Update(ParteDiario parteDiario)
        {
            _PromcoserContext.ParteDiario.Update(parteDiario);
            int countRows = await _PromcoserContext.SaveChangesAsync();
            return countRows > 0;
        }


        // Eliminar parte diario


        public async Task<bool> Delete(int id)
        {
            var parteDiario = await _PromcoserContext.ParteDiario.FindAsync(id);
            if (parteDiario == null)
            {
                return false;
            }
            _PromcoserContext.ParteDiario.Remove(parteDiario);
            int countRows = await _PromcoserContext.SaveChangesAsync();
            return countRows > 0;

        }





    }
}
