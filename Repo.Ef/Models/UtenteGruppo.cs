using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Ef.Models
{
    public class UtenteGruppo
    {
        public string UserId { get; set; }
        public int GroupId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Gruppo Gruppo { get; set; }

    }
}
