using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.User;

namespace LinternBackend.Token
{
    public interface ITokenService
    {
        string CreateToken(AppUser user, IList<string> userRoles);
    }
}