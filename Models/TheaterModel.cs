using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTicketBooking.Models
{
    public class TheaterModel
    {
        public string TheaterName { get; set; }
        public string Location { get; set; }
        public List<string> ShowTimings { get; set; }
        public bool IsCancellable { get; set; }
    }
}