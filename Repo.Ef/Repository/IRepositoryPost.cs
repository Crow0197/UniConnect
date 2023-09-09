using Repo.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef.Repository
{
    public interface IRepositoryPost
    {
        Task<IEnumerable<Post>> Get();
        

    }

}
