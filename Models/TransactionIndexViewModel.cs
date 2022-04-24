using ProjectEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Models
{
    public class TransactionIndexViewModel
    {
        public int Id { get; set; }
        public BookingRecord Booking { get; set; }
        public int BookingRecordId { get; set; }
        public string DepatureFrom { get; set; }
        public string SpecialRequest { get; set; }
        public string BookFother { get; set; }
        public string TicketType { get; set; }
        public string ArivalTo { get; set; }
         public decimal TravelPrice { get; set; }
        public decimal SpecialAmount { get; set; }
        public decimal BookAmount { get; set; }
        public decimal TicketAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
