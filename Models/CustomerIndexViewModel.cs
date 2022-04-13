using Microsoft.AspNetCore.Http;
using ProjectEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineBookingApplication.Models
{
    public class CustomerIndexViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="First Name field is required")]
        [StringLength(100)]
        [Display(Name="First Name")]
        [RegularExpression(@"^[A-Z][a-zA-Z""\s-]*$",ErrorMessage ="Invalid Input format")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last Name is required")]
        [RegularExpression(@"^[A-Z][a-zA-Z""\s-]*$", ErrorMessage = "Invalid Input format")]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(100)]
        public string FullName => FirstName +" "+ LastName;       
        [Required]
        [RegularExpression(@"^[1-9]{1}[0-9]{1}$",ErrorMessage = "incorrect input of Age")]
        public int Age{ get; set; }
        [Required]
        public string State { get; set; }
        [Required(ErrorMessage ="Phone number field required")]
        [RegularExpression(@"^[0-9]{11}$",ErrorMessage = "phone number is invalid")]
        [Display(Name ="Phone No")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[A-Z][a-zA-Z""/s-]*$", ErrorMessage = "Invalid input Format")]
        [Display(Name ="Next of kin Name")]
        public string NextOfKin { get; set; }
        [Required]
        public string NextOfKinGender { get; set; }
        [Required(ErrorMessage = "Phone number field required")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "phone number is invalid")]
        [Display(Name ="Next of kin Phone No")]
        public string NextofKinPhone { get; set; }
        [Required(ErrorMessage ="NiN field is required")]
        [StringLength(100)]
       [RegularExpression(@"^[1-9]{4}\s[0-9]{4}\s[0-9]{4}\s[0-9]{4}$", ErrorMessage ="Invalid National identity Number")]
        public string NIN { get; set; }
        [Display(Name ="Photo")]
        [Required(ErrorMessage ="Photo Field is required")]
        public IFormFile ImageUrl { get; set; }
        //public string Bus { get; set; } = "GUI Logistic";
        //[Required(ErrorMessage ="Date field is required")]
        //public DateTime Date { get; set; } = DateTime.Today;
        //[Required(ErrorMessage ="Departure From field is required")]
        //[Display(Name = "Departure From")]
        //public string DepartureFrom { get; set; }
        //[Required(ErrorMessage ="Arival To field is required")]
        //[Display(Name = "Arival To")]
        //public string ArivalTo { get; set; }
        //[Required(ErrorMessage ="Ticket Type Field is required")]
        //[Display(Name ="Ticket Type")]
        //public TicketType TicketType { get; set; }
        //[Required(ErrorMessage ="Seat no field is required")]
        //[Display(Name ="Seat No")]
        //public string SeatNo { get; set; }
        //[Display(Name = "Special Request")]
        //public SpecialRequest SpecialRequest { get; set; }
        //[Display(Name = "Book For Other")]
        //public BookForOther BookForOther { get; set; }
        //[Required(ErrorMessage ="Payment Type field is required")]
        //public Payment Payment { get; set; }
        //public IEnumerable<PaymentRecord> paymentRecords { get; set; }
    }
}
