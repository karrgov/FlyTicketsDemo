using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTickets.Models.Reservation
{
    public class ReserveViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        public int Laguage { get; set; }

        public Guid FlightId { get; set; }
    }
}
