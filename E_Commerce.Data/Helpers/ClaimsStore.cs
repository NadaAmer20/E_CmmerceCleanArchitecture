using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
namespace E_Commerce.Data.Helpers
{
    public static class ClaimsStore
    {
        public static List<Claim> claims = new()
        {
            new Claim("Create","False"),
            new Claim("Edit","False"),
            new Claim("Delete","False"),
        };
    }
}
