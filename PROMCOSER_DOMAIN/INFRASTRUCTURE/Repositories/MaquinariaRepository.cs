using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.CORE.Entities;
using PROMCOSER_DOMAIN.CORE.Interfaces;
using PROMCOSER_DOMAIN.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PROMCOSER_DOMAIN.Infrastructure.Repositories
{
    public class MaquinariaRepository : IMaquinariaRepository
    {
        private readonly PromcoserContext _dbContext;

        public MaquinariaRepository(PromcoserContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get all Maquinaria
        public async Task<IEnumerable<Maquinaria>> GetMaquinarias()
        {
            var maquinarias = await _dbContext.Maquinaria.//Where(c => c.Estado == true)
            ToListAsync();
            return maquinarias;
        }



        //Get Maquinarias by ID
        public async Task<Maquinaria> GetMaquinariaById(int id)
        {
            var maquinaria = await _dbContext
                .Maquinaria
                .Where(c => c.IdMaquinaria == id)
                .FirstOrDefaultAsync();
            return maquinaria;
        }

        // Get Maquinarias by Marca
        public async Task<IEnumerable<Maquinaria>> GetMaquinariasByMarca(string marca)
        {
            return await _dbContext.Maquinaria
                .Where(c => c.Marca == marca && c.Estado == true)
                .ToListAsync();
        }

        // Get Maquinarias by Modelo
        public async Task<IEnumerable<Maquinaria>> GetMaquinariasByModelo(string modelo)
        {
            return await _dbContext.Maquinaria
                .Where(c => c.Modelo == modelo && c.Estado == true)
                .ToListAsync();
        }

        //Get Maquinarias by Placa
        public async Task<Maquinaria> GetMaquinariaByPlaca(string placa)
        {
            var maquinaria = await _dbContext
                .Maquinaria
                .Where(c => c.Placa == placa && (c.Estado == true))
                .FirstOrDefaultAsync();
            return maquinaria;
        }

        //Crate Maquinaria
        public async Task<bool> Insert(Maquinaria maquinaria)
        {
            await _dbContext.Maquinaria.AddAsync(maquinaria);
            int countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;
        }

        //Update Maquinaria

        public async Task<bool> Update(int id, Maquinaria maquinaria)
        {
            var existingMaquinaria = await _dbContext.Maquinaria.FindAsync(id);

            if (existingMaquinaria == null)
            {
                return false;
            }

            existingMaquinaria.Placa = maquinaria.Placa;
            existingMaquinaria.Modelo = maquinaria.Modelo;
            existingMaquinaria.Marca = maquinaria.Marca;
            existingMaquinaria.AnioCompra = maquinaria.AnioCompra;
            existingMaquinaria.HorometroCompra = maquinaria.HorometroCompra;
            existingMaquinaria.HorometroActual = maquinaria.HorometroActual;
            existingMaquinaria.Estado = maquinaria.Estado;

            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }


        //Logilcal Delete Maquinaria
        public async Task<bool> LogicalDelete(int id)
        {
            var maquinaria = await _dbContext
                .Maquinaria
                .FirstOrDefaultAsync(c => c.IdMaquinaria == id);
            if (maquinaria == null) return false;

            maquinaria.Estado = false;
            int rows = await _dbContext.SaveChangesAsync();
            return (rows > 0);
        }

        //Delete Maquinaria
        public async Task<bool> Delete(int id)
        {
            var maquinaria = await _dbContext
                .Maquinaria
                .FirstOrDefaultAsync(c => c.IdMaquinaria == id);
            if (maquinaria == null) return false;

            _dbContext.Maquinaria.Remove(maquinaria);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

    }
}

