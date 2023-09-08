using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class GruppiResponse
    {
        public List<GruppoResponse> GruppiAssociati { get; set; }
        public List<GruppoResponse> GruppiCreati { get; set; }
        public List<GruppoResponse> AltriGruppi { get; set; }
    }


    public class GruppoResponse
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public string UserId { get; set; }
    }

}
