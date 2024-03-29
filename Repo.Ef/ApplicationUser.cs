﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Repo.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Group = new HashSet<Gruppo>();
            Eventi = new HashSet<Evento>();

        }

        public string Avatar  { get; set; }
        public string Universita { get; set; }

        public virtual ICollection<Gruppo> Group { get; set; }
        public virtual ICollection<Evento> Eventi { get; set; }

    

    }
}
