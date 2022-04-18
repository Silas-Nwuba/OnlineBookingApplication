﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookingApplication.Models
{
    public class BookingCreateViewModel
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public string NIN { get; set; }
        [Required(ErrorMessage = "Date Field is required")]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        public int CustomerId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string SeatNumber { get; set; }
        public SeatNo SeatNo { get; set; }
        [Display(Name = "Seat Number")]
        public int SeatNoId { get; set; }

        [Required(ErrorMessage = "Departure From Field is required")]
        [Display(Name = "Departure From")]
        public string DepartureFrom { get; set; }
        [Required(ErrorMessage = "Arival To Field is required")]
        [Display(Name = "Arival To")]
        public string ArivalTo { get; set; }
        [Required]
        [Display(Name = "Ticket Type")]
        public TicketType TicketType { get; set; }
        public string Bus { get; set; } = "GUI LOGISTIC";
        [Required]
        [Display(Name = "Special Request")]
        public SpecialRequest SpecialRequest { get; set; }

        public Payment Payment { get; set; }
        [Required]
        [Display(Name = "Book For Other")]
        public BookForOther BookForOther { get; set; }
        //[Required]
        ////public decimal TotalAmount { get; set; }
    }
}

