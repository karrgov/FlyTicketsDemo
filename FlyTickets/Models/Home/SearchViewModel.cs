using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTickets.Models.Home
{
    public class SearchViewModel
    {
        public DateTime DepartureTime { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public int PeopleCount { get; set; }
    }
}
