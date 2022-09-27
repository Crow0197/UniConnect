using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RememberMe.Response
{
    public class RegistrationResponse
    {
        public string Token { get; set; }
        public bool Result { get; set; }
        public List<string> Errors { get; set; }
    }
}
