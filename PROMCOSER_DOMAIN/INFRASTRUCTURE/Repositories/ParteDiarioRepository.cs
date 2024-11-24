using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.CORE.Entities;
using PROMCOSER_DOMAIN.CORE.Interfaces;
using PROMCOSER_DOMAIN.INFRASTRUCTURE.Data;

namespace PROMCOSER_DOMAIN.INFRASTRUCTURE.Repositories
{
    public class ParteDiarioRepository : IParteDiarioRepository
    {
        private readonly PromcoserContext _dbcontext;

        public ParteDiarioRepository(PromcoserContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<ParteDiario>> GetParteDiario()
        {
            var parteDiario = await _dbcontext.ParteDiario.ToListAsync();
            return parteDiario;
        }

        public async Task<ParteDiario> GetParteDiarioById(int id)
        {
            var parteDiario = await _dbcontext
                .ParteDiario.Where(c => c.IdParteDiario == id)
                .FirstOrDefaultAsync();
            return parteDiario;
        }

        public async Task<bool> Insert(ParteDiario parteDiario)
        {
            await _dbcontext.ParteDiario.AddAsync(parteDiario);
            int countRows = await _dbcontext.SaveChangesAsync();
            return countRows > 0;
        }
        public async Task<ParteDiario> Insert2(ParteDiario parteDiario)
        {
            await _dbcontext.ParteDiario.AddAsync(parteDiario);
            int countRows = await _dbcontext.SaveChangesAsync();
            return parteDiario;
        }

        public async Task<bool> Update(int id, ParteDiario parteDiario)
        {
            var existingParteDiario = await _dbcontext.ParteDiario.FindAsync(id);
            if (existingParteDiario == null)
            {
                return false;
            }

            existingParteDiario.Fecha = parteDiario.Fecha;
            existingParteDiario.Firmas = parteDiario.Firmas;
            existingParteDiario.HorometroInicio = parteDiario.HorometroInicio;
            existingParteDiario.HorometroFinal = parteDiario.HorometroFinal;
            existingParteDiario.IdCliente = parteDiario.IdCliente;
            existingParteDiario.IdPersonal = parteDiario.IdPersonal;
            existingParteDiario.IdMaquinaria = parteDiario.IdMaquinaria;
            existingParteDiario.LugarTrabajo = parteDiario.LugarTrabajo;
            existingParteDiario.Petroleo = parteDiario.Petroleo;
            existingParteDiario.Aceite = parteDiario.Aceite;
            existingParteDiario.ProximoMantenimiento = parteDiario.ProximoMantenimiento;

            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var parteDiario = await _dbcontext
                .ParteDiario
                .FirstOrDefaultAsync(c => c.IdParteDiario == id);
            if (parteDiario == null) return false;

            _dbcontext.ParteDiario.Remove(parteDiario);
            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> LogicalDelete(int id)
        {
            var parteDiario = await _dbcontext
                .ParteDiario
                .FirstOrDefaultAsync(c => c.IdParteDiario == id);
            if (parteDiario == null) return false;

            parteDiario.Firmas = false;
            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

    }
}
