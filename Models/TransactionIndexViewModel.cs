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
        public string FullName { get; set; }
        public string NiN { get; set; }
        public int SeatNo {get;set;}
        public string DepartureFrom { get; set; }
        public string Special { get; set; }
        public string Book { get; set; }
        public string Ticket { get; set; }
        public string ArivalTo { get; set; }
        public DateTime Date { get; set; }
        public decimal SpecialRequest { get; set; }
        public decimal BookForOther { get; set; }
        public decimal TicketType { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
