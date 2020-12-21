using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesSystem.Areas.Customers.Models
{
    public class TClients
    {
        [Key]
        public int IdClient { get; set; }
        public string Nid { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Direction { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public bool Credit { get; set; }
        public byte[] Image { get; set; }
        public List<TReports_clients> TReports_clients { get; set; }
    }
}
