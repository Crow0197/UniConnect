using Microsoft.EntityFrameworkCore;
using Repo.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef.Repository
{
    public class RepositoryCommento : IRepositoryCommento
    {
        private readonly DbContext _context;


        public RepositoryCommento(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Commento>> Get(int postId)
        {

            var gruppi = await _context.Commento
             .Include(g => g.User)
             .Where(g=> g.PostId == postId)
             .ToListAsync();
            return gruppi;



        }
    }
}
