using Microsoft.EntityFrameworkCore;
using Repo.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef
{
    public class RepositoryGruppi : IRepositoryGruppi
    {
        private readonly DbContext _context;


        public RepositoryGruppi(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gruppo>> GetGruppiAssociatiAsync(string idUtente)
        {

            var gruppi = await _context.Gruppo
             .Include(g => g.User)
             .Where(g => g.User.Any(u => u.Id == idUtente))
             .ToListAsync();
            return gruppi;



        }

        public async Task<IEnumerable<Gruppo>> GetGruppiCreatiAsync(string idUtente)
        {
            return await _context.Gruppo.Where(g => g.UserId == idUtente)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gruppo>> GetAltriGruppiAsync(string idUtente)
        {
            var gruppi = await _context.Gruppo
              .Include(g => g.User)
               .Where(g => !g.User.Any(u => u.Id == idUtente))
              .ToListAsync();
            return gruppi;
        }


        public async Task AddAsync(Gruppo entity, string idUser = null)
        {
            await _context.Set<Gruppo>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
