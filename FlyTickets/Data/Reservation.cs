using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTickets.Data
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid RouteId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Seats { get; set; }

        public int Laguage { get; set; }
    }
}
