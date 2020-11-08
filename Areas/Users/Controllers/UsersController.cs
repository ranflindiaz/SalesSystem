using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesSystem.Areas.Users.Controllers
{
    [Area("Users")]
    public class UsersController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
