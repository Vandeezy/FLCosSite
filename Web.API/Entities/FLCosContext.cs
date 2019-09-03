using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Entities
{
    public class FLCosContext: DbContext
    {
        public DbSet<Sport> Sports { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=M5290656\\SQLEXPRESS;Initial Catalog=FLCos;Integrated Security=True");
        }
    }
}
