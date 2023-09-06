using Repo.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniConnect.Response
{
    public class LoginResponse
    {

        public ApplicationUser User { get; set; }
        public string Token { get; set; }
        public bool Result { get; set; }
        public List<string> Errors { get; set; }
    }
}
