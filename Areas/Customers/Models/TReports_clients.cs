using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Areas.Customers.Models
{
    public class TReports_clients
    {
        [Key]
        public int IdReport { get; set; }
        public Decimal Debt { get; set; }
        public Decimal Monthly { get; set; }
        public Decimal Change { get; set; }
        public Decimal LastPayment { get; set; }
        public Decimal DatePayment { get; set; }
        public Decimal CurrentDebt { get; set; }
        public DateTime DateDebt { get; set; }
        public string Ticket { get; set; }
        public DateTime Deadline { get; set; }
        public int IdClient { get; set; }
        public TClients TClients { get; set; }
    }
}
