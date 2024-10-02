using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.ApplicationUser.Query.Results
{
    public class GetUserByIdResponse
    {
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string? ProfileImage { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
