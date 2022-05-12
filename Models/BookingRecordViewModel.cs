using ProjectEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Models
{
    public class BookingRecordViewModel
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public string NIN { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Today;
        public DateTime Dob { get; set; }
        public int CustomerId { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Required]
        public int TicketId { get; set; }
        public SeatNo SeatNo { get; set; }
        public string SeatNumber { get; set; }
        [Required(ErrorMessage ="Seat No field is required")]
        [Display(Name ="Seat No")]
        public int SeatNoId { get; set; }
        [Required(ErrorMessage ="Departure From field is required")]
        [Display(Name = "Departure From")]
        public string DepartureFrom {get; set;}
        [Required(ErrorMessage ="Arival To field is required")]
        [Display(Name = "Arival To")]
        public string ArivalTo { get; set; }
        [Required]
        [Display(Name ="Ticket Type")]
        public string TicketType { get; set; }
        [Required]
        public string Bus { get; set; } = "Peace Mass Motors";
        [Required]
        [Display(Name = "Special Request")]
        public string SpecialRequest { get; set; }
        [Required]
        public string Payment { get; set; }
        [Required]
        [Display(Name = "Book For Other")]
        public string BookForOther { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal TranvelPrice { get; set; }
        [Required]
        public decimal SpecialAmount { get; set; }
        [Required]
        public decimal BookAmount { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        
      
    }
}
