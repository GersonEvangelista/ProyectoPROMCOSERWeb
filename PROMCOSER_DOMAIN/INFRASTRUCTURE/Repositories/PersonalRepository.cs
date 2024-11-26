using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.CORE.Entities;
using PROMCOSER_DOMAIN.CORE.Interfaces;
using PROMCOSER_DOMAIN.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROMCOSER_DOMAIN.INFRASTRUCTURE.Repositories
{
    public class PersonalRepository : IPersonalRepository
    {
        public readonly PromcoserContext _context;

        public PersonalRepository(PromcoserContext context)
        {
            _context = context;
        }

        public async Task<Personal> SignIn(string username, string pwd)
        {
            return await _context.Personal.Where(u => u.Username == username && u.Password == pwd).FirstOrDefaultAsync();
        }

        public async Task<bool> SignUp(Personal personal)
        {
            await _context.Personal.AddAsync(personal);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<IEnumerable<Personal>> GetOperadores()
        {
            return await _context.Personal.Where(u => u.IdRol == 2).ToListAsync();
        }

        //ARON
        public async Task<IEnumerable<Personal>> GetPersonal()
        {
            var personal = await _context.Personal.ToListAsync();
            return personal;
        }

        //Get Personal by ID
        public async Task<Personal> GetPersonalById(int id)
        {
            var personal = await _context
                    .Personal
                    .Where(c => c.IdPersonal == id)
                    .FirstOrDefaultAsync();
            return personal;
        }

        //Create Personal
        public async Task<int> Insert(Personal personal)
        {
            bool dniExists = await _context.Personal.AnyAsync(p => p.Dni == personal.Dni);
            if (dniExists)
            {
                // Retorna -2 si el DNI ya está en uso
                return -2;
            }

            // Verificar si el Correo ya existe
            bool correoExists = await _context.Personal.AnyAsync(p => p.Correo == personal.Correo);
            if (correoExists)
            {
                // Retorna -3 si el Correo ya está en uso
                return -3;
            }
            personal.Estado = true;

            await _context.Personal.AddAsync(personal);
            int rows = await _context.SaveChangesAsync();

            if (rows > 0)
            {
                return (int)personal.IdPersonal;
            }
            else
            {
                return -1;
            }

        }

        //Update personal
        public async Task<bool> Update(Personal personal)
        {
            _context.Personal.Update(personal);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        // Delete personal
        public async Task<bool> Delete(int id)
        {
            var personal = await _context
                            .Personal
                            .FirstOrDefaultAsync(c => c.IdPersonal == id);

            if (personal == null) return false;

            // Eliminar el objeto de la base de datos
            _context.Personal.Remove(personal);
            int rows = await _context.SaveChangesAsync();
            return (rows > 0);
        }

        //Logilcal Delete personal
        public async Task<bool> LogicalDelete(int id)
        {
            var personal = await _context
                .Personal
                .FirstOrDefaultAsync(c => c.IdPersonal == id);
            if (personal == null) return false;

            personal.Estado = false;
            int rows = await _context.SaveChangesAsync();
            return (rows > 0);
        }

    }
}
