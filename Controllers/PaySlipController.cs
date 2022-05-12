using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingApplication.Models;
using ProjectEntity;
using ProjectServices;
using RotativaCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Controllers
{
    [Authorize]
    public class PaySlipController : Controller
    {
         private readonly IBookingRecord _Booking;
        public readonly ICustomer _customer;
      

        public PaySlipController(IBookingRecord bookingRecord , ICustomer customer)
        {
            _customer = customer;
            _Booking = bookingRecord;
        }
        public IActionResult Index(int id)
        {
            var ViewModel = _Booking.GetById(id);
            if(ViewModel == null)
            {
                return NotFound();
            }
            var Model = new PaySlipViewModel
            {
                Id = ViewModel.Id,
                CustomerId = ViewModel.CustomerId,
                FullName = ViewModel.FullName,
                TravelLoction = ViewModel.DepartureFrom,
                TravelArival = ViewModel.ArivalTo,
                Gender = _customer.GetAsyncId(ViewModel.CustomerId).Gender,
                Phone = _customer.GetAsyncId(ViewModel.CustomerId).PhoneNumber,
                State = _customer.GetAsyncId(ViewModel.CustomerId).State,
                SeatNoId = ViewModel.SeatNoId,
                SpecialRequest = ViewModel.SpecialRequest,
                BookForOther = ViewModel.BookForOther,
                TicketType = ViewModel.TicketType,
                Price = ViewModel.TranvelPrice,
                SpecialAmount = ViewModel.SpecialAmount,
                BookAmount = ViewModel.BookAmount,
                TicketAmount = ViewModel.TicketAmount,
                TotalAmount = ViewModel.TotalAmount,
            };
            return View(Model);
        }
        public IActionResult Pdf(int id)
        {
            var ViewModel = _Booking.GetById(id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            var Model = new PaySlipViewModel
            {
                Id = ViewModel.Id,
                CustomerId = ViewModel.CustomerId,
                FullName = ViewModel.FullName,
                TravelLoction = ViewModel.DepartureFrom,
                TravelArival = ViewModel.ArivalTo,
                Gender = _customer.GetAsyncId(ViewModel.CustomerId).Gender,
                Phone = _customer.GetAsyncId(ViewModel.CustomerId).PhoneNumber,
                State = _customer.GetAsyncId(ViewModel.CustomerId).State,
                SeatNoId = ViewModel.SeatNoId,
                SpecialRequest = ViewModel.SpecialRequest,
                BookForOther = ViewModel.BookForOther,
                TicketType = ViewModel.TicketType,
                Price = ViewModel.TranvelPrice,
                SpecialAmount = ViewModel.SpecialAmount,
                BookAmount = ViewModel.BookAmount,
                TicketAmount = ViewModel.TicketAmount,
                TotalAmount = ViewModel.TotalAmount,
            };
            return View(Model);
        }
        public IActionResult Payslip(int Id)
        {
            var Payslip = new ActionAsPdf("Pdf", new { id = Id })
            {
                FileName = "GMT-Payslip.pdf",
            };
            return Payslip;
        }
    }
}
