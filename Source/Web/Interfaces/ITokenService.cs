using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;

namespace Web.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user);
    }
}
