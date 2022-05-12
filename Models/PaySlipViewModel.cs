using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Models
{
    public class PaySlipViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string TravelLoction { get; set; }
        public string TravelArival { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public int SeatNoId { get; set; }
        public DateTime Date { get; set; }
        public string BookForOther { get; set; }
        public string TicketType { get; set; }
        public string SpecialRequest { get; set; }
        public decimal SpecialAmount { get; set; }
        public decimal TicketAmount { get; set; }
        public decimal BookAmount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Verified";
    }
}
