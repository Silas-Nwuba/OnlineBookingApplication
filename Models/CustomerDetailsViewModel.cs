﻿using Microsoft.AspNetCore.Http;
using ProjectEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Models
{
    public class CustomerDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Date")]
        public DateTime Dob { get; set; }
        public string State { get; set; }
        [Display(Name = "Phone No")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Gender Gender { get; set; }

        [StringLength(100)]

        [Display(Name = "Next of kin Name")]
        public string NextOfKin { get; set; }

        public string NextOfKinGender { get; set; }
        [Required(ErrorMessage = "Phone number field required")]

        [Display(Name = "Next of kin Phone No")]
        public string NextofKinPhone { get; set; }

        [StringLength(100)]

        public string NIN { get; set; }
        [Display(Name = "Photo")]

        public string ImageUrl { get; set; }
        public string Bus { get; set; } = "GUI Logistic";

        public DateTime Date { get; set; } = DateTime.Today;

        [Display(Name = "Departure From")]
        public string DepartureFrom { get; set; }

        [Display(Name = "Arival To")]
        public string ArivalTo { get; set; }

        [Display(Name = "Ticket Type")]
        public TicketType TicketType { get; set; }

        [Display(Name = "Seat No")]
        public string SeatNo { get; set; }
        [Display(Name = "Special Request")]
        public SpecialRequest SpecialRequest { get; set; }
        [Display(Name = "Book For Other")]
        public BookForOther BookForOther { get; set; }
        public decimal TotalAmount { get; set; }
        public Payment Payment { get; set; }
    }
}
