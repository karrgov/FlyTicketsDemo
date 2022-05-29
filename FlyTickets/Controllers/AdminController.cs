using FlyTickets.Data;
using FlyTickets.Data.Repository;
using FlyTickets.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FlyTickets.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<Route> _repo;
        private IRepository<IdentityUser> _userRepo;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> _userManager;

        public AdminController(IRepository<Route> repo, IRepository<IdentityUser> userRepo, UserManager<IdentityUser> userManager)
        {
            this._repo = repo;
            this._userRepo = userRepo;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddRoute()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRoute(AddRouteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var route=new Route 
            { 
                ArivalAirport=model.ArivalAirport,
                ArivalCity=model.ArivalCity,
                ArivalTerminal=model.ArivalTerminal,
                ArrivalTime=model.ArrivalDate,
                DepartureAirport=model.DepartureAirport,
                DepartureCity=model.DepartureCity,
                DepartureTerminal=model.DepartureTerminal,
                DepartureTime=model.DepartureDate,
                Plane=model.Plane,
                Price=model.Price,
                Seats=model.Seats,
                Active=true
            };
            route.ArrivalTime+=(model.ArrivalTime);
            route.DepartureTime+=(model.DepartureTime);

            _repo.Insert(route);
            _repo.Save();
            return Redirect("/Admin/AddRoute");
        }

        [HttpGet]
        public IActionResult AllFlights()
        {
            var allFlights=this._repo.GetAll().ToArray();
            return View(allFlights);
        }

        [HttpGet]
        public IActionResult FlightDetails(Guid id)
        {
            var flight = this._repo.GetById(id);
            return View(flight);
        }

        [HttpPost]
        public IActionResult FlightDetails(Route model)
        {
            this._repo.Update(model);
            this._repo.Save();
            return Redirect("/Admin/AllFlights");
        }

        [HttpGet]
        public IActionResult AllUsers()
        {
            var users = this._userRepo.GetAll();
            return View(users);
        }
    }
}
