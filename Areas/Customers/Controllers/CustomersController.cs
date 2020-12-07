using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class CustomersController : Controller
    {
        public IActionResult Customers()
        {
            return View();
        }
    }
}
