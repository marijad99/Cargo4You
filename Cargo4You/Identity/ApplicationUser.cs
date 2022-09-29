using System;
using Microsoft.AspNetCore.Identity;

namespace Cargo4You.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public int? OrganisationId { get; set; }
    }
}
