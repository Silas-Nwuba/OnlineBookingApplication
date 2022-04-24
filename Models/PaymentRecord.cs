using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Models
{
    public class PaymentRecord
    {
        public int Id { get; set; }
        public string SpecialRequest { get; set; }
        public string BookForOther {get;set;}
        public string TicketType { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
