using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RememberMe.Data.Request
{
    public class MoveSetCreationRequest
    {
        public Guid PgId { get; set; }
        public List<MoveSet> moveSets { get; set; }

    }


    public class MoveSet
    {
        public int TypologyID { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }

    }
}
