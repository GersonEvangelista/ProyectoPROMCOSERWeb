using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.Core.Entities;
using PROMCOSER_DOMAIN.Core.Interfaces;
using PROMCOSER_DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROMCOSER_DOMAIN.Infrastructure.Repositories
{
    public class DetalleParteDiarioRepository : IDetalleParteDiarioRepository
    {
        private readonly PromcoserContext _dbContext;

        public DetalleParteDiarioRepository(PromcoserContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obtener todos los detalles
        public async Task<IEnumerable<DetalleParteDiario>> GetDetalles()
        {
            return await _dbContext.DetalleParteDiario.ToListAsync();
        }

        // Obtener un detalle por ID
        public async Task<DetalleParteDiario> GetDetalleById(long id)
        {
            return await _dbContext.DetalleParteDiario.FirstOrDefaultAsync(d => d.IdDetalleParteDiario == id);
        }

        // Obtener detalles por ID de parte diario
        public async Task<IEnumerable<DetalleParteDiario>> GetDetallesByParteDiarioId(long parteDiarioId)
        {
            return await _dbContext.DetalleParteDiario
                .Where(d => d.ParteDiarioId == parteDiarioId)
                .ToListAsync();
        }

        // Insertar un nuevo detalle
        public async Task<long> Insert(DetalleParteDiario detalleParteDiario)
        {
            await _dbContext.DetalleParteDiario.AddAsync(detalleParteDiario);
            await _dbContext.SaveChangesAsync();
            return detalleParteDiario.IdDetalleParteDiario;
        }

        // Actualizar un detalle existente
        public async Task<bool> Update(DetalleParteDiario detalleParteDiario)
        {
            _dbContext.DetalleParteDiario.Update(detalleParteDiario);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Eliminar un detalle (de forma lógica o física)
        public async Task<bool> Delete(long id)
        {
            var detalleParteDiario = await _dbContext.DetalleParteDiario.FirstOrDefaultAsync(d => d.IdDetalleParteDiario == id);

            if (detalleParteDiario == null) return false;

            _dbContext.DetalleParteDiario.Remove(detalleParteDiario);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
