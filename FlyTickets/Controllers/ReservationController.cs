using FlyTickets.Data;
using FlyTickets.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTickets.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IRepository<Reservation> repo;

        public ReservationController(IRepository<Reservation> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult Reserve(Guid id)
        {
            var reservation = new Reservation { RouteId = id };
            return View();
        }

        [HttpPost]
        public IActionResult Reserve(Reservation reservation)
        {
            repo.Insert(reservation);
            repo.Save();
            return Redirect("/Home/Index");
        }
    }
}
