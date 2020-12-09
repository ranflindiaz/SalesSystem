using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Areas.Customers.Models;
using SalesSystem.Data;
using SalesSystem.Library;

namespace SalesSystem.Areas.Customers.Pages.Account
{
    [Authorize]
    [Area("Customers")]
    public class RegisterModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;
        private static InputModel _dataInput;
        private Uploadimage _uploadImage;
        private static InputModelRegister _dataClient1, _dataClient2;
        private IWebHostEnvironment _environment;

        public RegisterModel(
                            UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager,
                            RoleManager<IdentityRole> roleManager,
                            ApplicationDbContext context,
                            IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _environment = environment;
            _uploadImage = new Uploadimage();
        }
        public void OnGet()
        {
            Input = new InputModel
            {

            };
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel : InputModelRegister
        {
            public IFormFile AvatarImage { get; set; }

        }
        public async Task<IActionResult> OnPost(String dataClient)
        {
            if (dataClient == null)
            {
                if (_dataClient2 == null)
                {
                    if (User.IsInRole("Admin"))
                    {
                        if (await SaveAsync())
                        {
                            return Redirect("/Customers/Customers?area=Customers");
                        }
                        else
                        {
                            return Redirect("/Customers/Register");
                        }
                    }
                    else
                    {
                        return Redirect("/Customers/Customers?area=Customers");
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return Redirect("/Customers/Register?id=1");
            }
        }
        public async Task<bool> SaveAsync()
        {
            _dataInput = Input;
            var valor = false;
            if (ModelState.IsValid)
            {
                var clientList = _context.TClients.Where(u => u.Nid.Equals(Input.Nid)).ToList();
                if (clientList.Count.Equals(0))
                {
                    var strategy = _context.Database.CreateExecutionStrategy();
                    await strategy.ExecuteAsync(async () => {
                        using (var transaction = _context.Database.BeginTransaction())
                        {
                            try
                            {
                                var imageByte = await _uploadImage.ByteAvatarImageAsync(Input.AvatarImage,
                                    _environment, "images/images/default.png");
                                var client = new TClients
                                {
                                    Name = Input.Name,
                                    LastName = Input.LastName,
                                    Nid = Input.Nid,
                                    Email = Input.Email,
                                    Image = imageByte,
                                    Phone = Input.Phone,
                                    Direction = Input.Direction,
                                    Credit = Input.Credit,
                                    Date = DateTime.Now
                                };
                                await _context.AddAsync(client);
                                _context.SaveChanges();
                                var report = new TReports_clients
                                {
                                    Debt = 0.0m,
                                    Monthly = 0.0m,
                                    Change = 0.0m,
                                    LastPayment = 0.0m,
                                    CurrentDebt = 0.0m,
                                    Ticket = "0000000000",
                                    TClients = client
                                };
                                await _context.AddAsync(report);
                                _context.SaveChanges();
                                transaction.Commit();
                                _dataInput = null;
                                valor = true;
                            }
                            catch (Exception ex)
                            {

                                _dataInput.ErrorMessage = ex.Message;
                                transaction.Rollback();
                                valor = false;
                            }
                        }
                    });
                }
                else
                {
                    _dataInput.ErrorMessage = $"El {Input.Nid} ya esta registrado";
                    valor = false;
                }
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _dataInput.ErrorMessage += error.ErrorMessage;
                    }
                }
                valor = false;
            }
            return valor;
        }
    }
}
