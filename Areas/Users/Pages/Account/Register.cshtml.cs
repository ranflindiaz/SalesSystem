using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesSystem.Areas.Users.Models;
using SalesSystem.Library;

namespace SalesSystem.Areas.Users.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private SignInManager<IdentityUser> _singInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private LUsersRoles _usersRole;

        public RegisterModel(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _singInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _usersRole = new LUsersRoles(); 
        }

        public void OnGet()
        {
            Input = new InputModel
            {
                rolesLista = _usersRole.getRoles(_roleManager)
            };
        }


        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel : InputModelRegister
        {
            public IFormFile AvatarImage { get; set; }

            public string ErrorMessage { get; set; }

            public List<SelectListItem> rolesLista { get; set; }
        }
    }
}
