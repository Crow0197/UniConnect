using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
