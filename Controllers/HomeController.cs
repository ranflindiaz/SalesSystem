using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SalesSystem.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SalesSystem.Controllers
{
    public class HomeController : Controller
    {
        //IServiceProvider _serviceProvider;

        public HomeController(IServiceProvider serviceProvider)
        {
            //_serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            //await CreateRolesAsync(_serviceProvider);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task CreateRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            String[]  rolesName = { "Admin", "User"};
            foreach (var item in rolesName)
            {
                var roleExist = await roleManager.RoleExistsAsync(item);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(item));
                }
            }
        }
    }
}
