using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.CORE.DTO;
using PROMCOSER_DOMAIN.CORE.Entities;
using PROMCOSER_DOMAIN.CORE.Interfaces;
using PROMCOSER_DOMAIN.INFRASTRUCTURE.Data;

namespace PROMCOSER_DOMAIN.INFRASTRUCTURE.Repositories
{
    public class DetalleParteDiarioRepository : IDetalleParteDiarioRepository
    {
        private readonly PromcoserContext _dbcontext;

        public DetalleParteDiarioRepository(PromcoserContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<DetalleParteDiario>> GetDetalleParteDiario()
        {
            var detalleparteDiario = await _dbcontext.DetalleParteDiario.ToListAsync();
            return detalleparteDiario;
        }

        public async Task<DetalleParteDiario> GetDetalleParteDiarioById(int id)
        {
            var detalleparteDiario = await _dbcontext
                .DetalleParteDiario.Where(c => c.IdDetalleParteDiario == id)
                .FirstOrDefaultAsync();
            return detalleparteDiario;
        }

        public async Task<bool> Insert(DetalleParteDiario detalleparteDiario)
        {
            await _dbcontext.DetalleParteDiario.AddAsync(detalleparteDiario);
            int countRows = await _dbcontext.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Update(int id, DetalleParteDiario detalleparteDiario)
        {
            var existingDetalleParteDiario = await _dbcontext.DetalleParteDiario.FindAsync(id);
            if (existingDetalleParteDiario == null)
            {
                return false;
            }

            existingDetalleParteDiario.Descripcion = detalleparteDiario.Descripcion;
            existingDetalleParteDiario.IdParteDiario = detalleparteDiario.IdParteDiario;
            existingDetalleParteDiario.Horas = detalleparteDiario.Horas;
            existingDetalleParteDiario.TrabajoEfectuado = detalleparteDiario.TrabajoEfectuado;

            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var detalleparteDiario = await _dbcontext
                .DetalleParteDiario
                .FirstOrDefaultAsync(c => c.IdDetalleParteDiario == id);
            if (detalleparteDiario == null) return false;

            _dbcontext.DetalleParteDiario.Remove(detalleparteDiario);
            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
