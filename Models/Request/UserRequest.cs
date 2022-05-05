using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{    public class UserRequest
    {
   public string UserName { get; set; }
       
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime DateOfBirth = new DateTime();
        public string Email { get; set; }
        public string Password { get; set; }
        public string TypeAccount { get; set; }
        public string Avatar { get; set; }   

    }
}
