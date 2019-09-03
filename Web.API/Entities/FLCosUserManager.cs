using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FLCosUserManager : UserManager<IdentityUser>
    {
        public FLCosUserManager() : base(new FLCosUserStore())
        {
        }
    }

    public class FLCosUserStore : UserStore<IdentityUser>
    {
        public FLCosUserStore() : base(new BooksContext())
        {
        }
    }
}
