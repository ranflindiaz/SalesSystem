using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Areas.Principal
{
    [Area("Principal")]
    public class PrincipalController : Controller
    {
        public IActionResult Principal()
        {
            return View();
        }
    }
}
