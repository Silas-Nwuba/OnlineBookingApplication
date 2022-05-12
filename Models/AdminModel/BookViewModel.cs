using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectEntity;
namespace OnlineBookingApplication.Models.AdminModel
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Bus { get; set; }
        public string SpecialRequest { get; set; }
        public string BookForOther { get; set; }
        public string TicketType { get; set; }
        public string DepartureFrom { get; set; }
        public string ArivalTo { get; set; }
        public string Payment { get;set; }
        public int SeatNoId { get; set; }
    }
}
