using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class PostResponse
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public int NumeroCommenti { get; set; }


        public DateTime? Timestamp { get; set; }
        public UserDto User { get; set; } // Usiamo il DTO dell'utente invece di ApplicationUser
        public int? FileId { get; set; }
        public int? GroupId { get; set; }
    }   

}
