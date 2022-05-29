using FlyTickets.Data;
using FlyTickets.Data.Repository;
using FlyTickets.Models;
using FlyTickets.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Route> repo;

        public HomeController(IRepository<Route> repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {
            var allRoutes=this.repo.GetAll();

            allRoutes = allRoutes
                .Where(x => x.Active)
                .Where(x => x.DepartureTime.AddDays(3) >= model.DepartureTime && x.DepartureTime.AddDays(-3) <= model.DepartureTime)
                .Where(x => x.DepartureCity == model.From && x.ArivalCity == model.To)
                .ToArray();

            return View(allRoutes);
        }

        [HttpGet]
        public IActionResult FlightDetails(Guid id)
        {
            var route = this.repo.GetById(id);

            return View(route);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
