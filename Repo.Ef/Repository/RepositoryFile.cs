using Microsoft.EntityFrameworkCore;
using Repo.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef.Repository
{
    public class RepositoryFile : IRepositoryFile
    {
        private readonly DbContext _context;


        public RepositoryFile(DbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(FileStorage entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity.FileId; // Restituisci l'ID generato automaticamente
        }
    }
}
