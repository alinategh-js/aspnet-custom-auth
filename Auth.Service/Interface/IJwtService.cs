using Auth.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Service.Interface
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);
    }
}
