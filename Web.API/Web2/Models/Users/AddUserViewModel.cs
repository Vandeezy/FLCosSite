using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web2.Models.Users
{
    public class AddUserViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}