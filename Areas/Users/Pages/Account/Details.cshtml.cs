using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesSystem.Areas.Users.Models;
using SalesSystem.Data;
using SalesSystem.Library;
using System.Linq;

namespace SalesSystem.Areas.Users.Pages.Account
{
    public class DetailsModel : PageModel
    {
        public SignInManager<IdentityUser> _signInManager { get; set; }
        private LUser _user;
        public DetailsModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _user = new LUser(userManager, signInManager, roleManager, context);
        }

        public void OnGet(int id)
        {
            var data = _user.getTUsuariosAsync(null, id);
            if (0 < data.Result.Count)
            {
                Input = new InputModel
                {
                    DataUser = data.Result.ToList().Last()
                };

            }
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public InputModelRegister DataUser { get; set; }
        }
    }
}
