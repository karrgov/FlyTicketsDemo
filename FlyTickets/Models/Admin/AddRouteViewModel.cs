using System;
using System.ComponentModel.DataAnnotations;

namespace FlyTickets.Models.Admin
{
    public class AddRouteViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string DepartureCity { get; set; }

        [Required]
        public string DepartureAirport { get; set; }
        
        [Required]
        public string DepartureTerminal { get; set; }

        [Required]
        public string ArivalCity { get; set; }

        [Required]
        public string ArivalAirport { get; set; }

        [Required]
        public string ArivalTerminal { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public TimeSpan DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public TimeSpan ArrivalTime { get; set; }
        [Required]
        public int Seats { get; set; }
        [Required]
        public string Plane { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
