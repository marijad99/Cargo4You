using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Cargo4You.Identity
{
    public class ApplicationDbContextCustom : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContextCustom(DbContextOptions<ApplicationDbContextCustom> options) : base(options)
        {
        }

        protected ApplicationDbContextCustom()
        {
        }
    }
}
