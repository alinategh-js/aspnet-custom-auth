using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Api.Models
{
    public class SignInModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
