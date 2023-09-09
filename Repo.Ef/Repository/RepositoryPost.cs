using Microsoft.EntityFrameworkCore;
using Repo.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef.Repository
{
    public class RepositoryPost : IRepositoryPost
    {
        private readonly DbContext _context;

     
        public RepositoryPost(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> Get()
        {

            var gruppi = await _context.Post
             .Include(g => g.User)
             .Include(g => g.Commento)
             .ToListAsync();
            return gruppi;



        }
    }
}
