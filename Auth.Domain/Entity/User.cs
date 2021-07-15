using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Auth.Domain.Entity
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
