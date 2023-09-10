using Repo.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef.Repository
{
    public interface IRepositoryEventi
    {
        Task<IEnumerable<Evento>> GetEventiAssociatiAsync(string idUtente);
        Task<IEnumerable<Evento>> GetEventiCreatiAsync(string idUtente);
        Task<IEnumerable<Evento>> GetAltriEventiAsync(string idUtente);
        Task AddAsync(Evento entity, string idUser = null);

    }

}
