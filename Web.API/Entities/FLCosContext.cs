using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Entities
{
    public class FLCosContext: DbContext
    {
        public DbSet<Sport> Sports { get; set; }

    }
}
