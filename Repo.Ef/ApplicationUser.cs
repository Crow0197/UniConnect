using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef
{
    public class ApplicationUser : IdentityUser
    {

        public virtual ICollection<Pg> Pgs { get; set; }

        public string Avatar  { get; set; }

    }
}
