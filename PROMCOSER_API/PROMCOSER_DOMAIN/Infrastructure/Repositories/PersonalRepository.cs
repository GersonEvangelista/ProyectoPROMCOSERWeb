using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.Core.Entities;
using PROMCOSER_DOMAIN.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROMCOSER_DOMAIN.Infrastructure.Repositories
{
    public class PersonalRepository
    {
        private readonly PromcoserContext _promcoserContext;

        public PersonalRepository(PromcoserContext promcoserContext)
        {
            _promcoserContext = promcoserContext;
        }

        public async Task<IEnumerable<Personal>> GetPeople()
        {
            var people = await _promcoserContext.Personal.Where(c => c.Estado == "T").ToListAsync();
            return people;
        }

        public async Task<Personal> GetPersonalById(int id)
        {
            var personal = await _promcoserContext.Personal.Where(c => c.IdPersonal == id && c.Estado == "T").FirstOrDefaultAsync();
            return personal;
        }

        public async Task<int> Insert(Personal personal)
        {
            personal.Estado = "T";
            await _promcoserContext.Personal.AddAsync(personal);
            return await _promcoserContext.SaveChangesAsync();
            //int rows = await _promcoserContext.SaveChangesAsync();

            //return rows > 0 ? personal.IdPersonal : -1;
        }

        public async Task<bool> Update(Personal personal)
        {
            _promcoserContext.Personal.Update(personal);
            int rows = await _promcoserContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var personal = await _promcoserContext.Personal.FirstOrDefaultAsync(c => c.IdPersonal == id);

            if (personal == null) return false;
            personal.Estado = "F";
            int rows = await _promcoserContext.SaveChangesAsync();
            return rows > 0;

            //_promcoserContext.Personal.Remove(personal);
        } 



    }
}
