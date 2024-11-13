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
    }
}
