﻿using Repo.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef.Repository
{
    public interface IRepositoryCommento
    {
        Task<IEnumerable<Commento>> Get(int postId);

    }

}
