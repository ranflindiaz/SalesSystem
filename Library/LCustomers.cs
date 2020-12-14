using SalesSystem.Areas.Customers.Models;
using SalesSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Library
{
    public class LCustomers : ListObject
    {
        public LCustomers(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<InputModelRegister> getTClients(String valor, int id)
        {
            List<TClients> listClients;
            var clientsList = new List<InputModelRegister>();
            if (valor == null && id.Equals(0))
            {
                listClients = _context.TClients.ToList();
            }
            else
            {
                if (id.Equals(0))
                {
                    listClients = _context.TClients.Where(u => u.Nid.StartsWith(valor) || u.Name.StartsWith(valor) ||
                    u.LastName.StartsWith(valor) || u.Phone.StartsWith(valor)).ToList();
                }
                else
                {
                    listClients = _context.TClients.Where(u => u.IdClient.Equals(id)).ToList();
                }
            }
            if (!listClients.Count.Equals(0))
            {
                foreach (var item in listClients)
                {
                    clientsList.Add(new InputModelRegister
                    {
                        IdClient = item.IdClient,
                        Nid = item.Nid,
                        Name = item.Name,
                        LastName = item.LastName,
                        Email = item.Email,
                        Phone = item.Phone,
                        Credit = item.Credit,
                        Direction = item.Direction,
                        Image = item.Image
                    });
                }
            }
            return clientsList;
        }

        public List<TClients> getTClient(String Nid)
        {
            var listClients = new List<TClients>();
            using (var dbContext = new ApplicationDbContext())
            {
                listClients = dbContext.TClients.Where(u => u.Nid.Equals(Nid)).ToList();
            }
            
            return listClients;
        }
    }
}
