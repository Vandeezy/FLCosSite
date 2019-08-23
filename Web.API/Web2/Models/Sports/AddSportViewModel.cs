using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Sports
{
    public class AddSportViewModel
    {
        public DateTime Date { get; set; }

        public int Steps { get; set; }

        public int UserId { get; set; }
    }
}