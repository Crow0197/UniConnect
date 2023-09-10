using Microsoft.EntityFrameworkCore;
using Repo.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef.Repository
{
    public class RepositoryEventi : IRepositoryEventi
    {
        private readonly DbContext _context;


        public RepositoryEventi(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetEventiAssociatiAsync(string idUtente)
        {

            var Eventi = await _context.Evento
             .Include(g => g.User)
             .Where(g => g.User.Any(u => u.Id == idUtente))
             .ToListAsync();
            return Eventi;



        }

        public async Task<IEnumerable<Evento>> GetEventiCreatiAsync(string idUtente)
        {
            return await _context.Evento.Where(g => g.UserId == idUtente)
                .ToListAsync();
        }

        public async Task<IEnumerable<Evento>> GetAltriEventiAsync(string idUtente)
        {
            var Eventi = await _context.Evento
              .Include(g => g.User)
               .Where(g => !g.User.Any(u => u.Id == idUtente))
              .ToListAsync();
            return Eventi;
        }


        public async Task AddAsync(Evento entity, string idUser = null)
        {
            await _context.Set<Evento>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
