using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlyTickets.Controllers
{
    public class UserController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<IActionResult> MyInformation()
        {
            var user=await _userManager.GetUserAsync(User);
            return View(user);
        }
        public IActionResult MyTrips()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
