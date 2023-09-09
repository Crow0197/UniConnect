using Repo.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef.Repository
{
    public interface IRepositoryGruppi
    {
        Task<IEnumerable<Gruppo>> GetGruppiAssociatiAsync(string idUtente);
        Task<IEnumerable<Gruppo>> GetGruppiCreatiAsync(string idUtente);
        Task<IEnumerable<Gruppo>> GetAltriGruppiAsync(string idUtente);
        Task AddAsync(Gruppo entity, string idUser = null);

    }

}
