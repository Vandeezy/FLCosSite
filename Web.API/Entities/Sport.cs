using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sport
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int Steps { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}
