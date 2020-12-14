using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Areas.Customers.Models;
using SalesSystem.Areas.Users.Models;

namespace SalesSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        static DbContextOptions<ApplicationDbContext> _option;
        public ApplicationDbContext() : base(_option)
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _option = options;
        }
        public DbSet<TUsers> TUsers { get; set; }
        public DbSet<TClients> TClients { get; set; }
        public DbSet<TReports_clients> TReports_clients { get; set; }
    }
}
