using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTickets.Data
{
    public class Route
    {
        public Guid Id { get; set; }

        public string DepartureCity { get; set; }

        public string DepartureAirport { get; set; }

        public string DepartureTerminal { get; set; }


        public string ArivalCity { get; set; }

        public string ArivalAirport { get; set; }

        public string ArivalTerminal { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public int Seats { get; set; }

        public string Plane { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }
    }
}
