using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingApplication.Models;
using OnlineBookingApplication.Models.AdminModel;
using ProjectEntity;
using ProjectServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Controllers.AdminControllers
{
    [Authorize]
    public class AdminBookController : Controller
    {
        private readonly IBookingRecord _booking;
        private readonly ICustomer _customer;
        private readonly ICharges _charges;
        private readonly ITicketType _Ticket;
        private string depart;
        private string Arival;

        private string Ticket;
        private string book;

        private decimal TotalAmount;

        private decimal bookAmount;
        private string request;
        private decimal specialAmount;
        private decimal travel;
        private decimal TicketAmount;
        private decimal travelprice;

        public AdminBookController(IBookingRecord bookingRecord, ICustomer customer, ICharges charges, ITicketType ticketType)
        {
            _booking = bookingRecord;
            _customer = customer;
            _charges = charges;
            _Ticket = ticketType;
        }
        public IActionResult Index1(int? PageNumber)
        {
            var ViewModel = _booking.GetAll().Select(Book => new BookViewModel()
            {
                Id = Book.Id,
                Bus = Book.Bus,
                TicketType = Book.TicketType,
                ArivalTo = Book.ArivalTo,
                DepartureFrom = Book.DepartureFrom,
                BookForOther = Book.BookForOther,
                SpecialRequest = Book.SpecialRequest,
                Payment = Book.Payment,
                SeatNoId = Book.SeatNoId,
            }).ToList();
            int PageSize = 5;
            return View(Pagination<BookViewModel>.Create(ViewModel, PageNumber ?? 1, PageSize));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.SeatNoId = _booking.GetSeatNo();
            var Get = _booking.GetById(id);
            if (Get == null)
            {
                return NotFound();
            }
            var ViewModel = new BookingRecordViewModel()
            {
                Id = Get.Id,
                FullName = Get.FullName,
                NIN = Get.NiN,
                CustomerId = Get.CustomerId,
                Bus = Get.Bus,
                ArivalTo = Get.ArivalTo,
                DepartureFrom = Get.DepartureFrom,
                SeatNoId = Get.SeatNoId,
                BookForOther = Get.BookForOther,
                SpecialRequest = Get.SpecialRequest,
                TicketType = Get.TicketType,
                Date = Get.Date,
            };
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBook(BookingRecordViewModel bookingRecordViewModel)
        {
            var Get = _booking.GetById(bookingRecordViewModel.Id);
            if (Get == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Get.Id = bookingRecordViewModel.Id;
                Get.FullName = bookingRecordViewModel.FullName;
                Get.NiN = bookingRecordViewModel.NIN;
                Get.CustomerId = bookingRecordViewModel.CustomerId;
                Get.Bus = bookingRecordViewModel.Bus;
                Get.Date = bookingRecordViewModel.Date;
                Get.SeatNoId = bookingRecordViewModel.SeatNoId;
                Get.SpecialRequest = request = bookingRecordViewModel.SpecialRequest;
                Get.Payment = bookingRecordViewModel.Payment;
                Get.BookForOther = book = bookingRecordViewModel.BookForOther;
                Get.BookAmount = bookAmount = _booking.BookForOther(book);
                Get.SpecialAmount = specialAmount = _booking.GetSpecial(request);

            }
            else if (Get.ArivalTo != bookingRecordViewModel.ArivalTo || Get.DepartureFrom != bookingRecordViewModel.DepartureFrom)
            {
                Get.ArivalTo = Arival = bookingRecordViewModel.ArivalTo;
                Get.DepartureFrom = depart = bookingRecordViewModel.DepartureFrom;
                Get.TranvelPrice = travel = _booking.GetDepartAndArival(depart, Arival);
                Get.TranvelPrice = travelprice = _charges.GetCharges(travel);
                Get.TotalAmount = TotalAmount = _booking.TotalAmount(travelprice, bookAmount, specialAmount, TicketAmount);
            }
            else
            {
                Get.TicketType = Ticket = bookingRecordViewModel.TicketType;
                Get.TicketAmount = TicketAmount = _booking.TicketType(Ticket);
                Get.ArivalTo = Arival = bookingRecordViewModel.ArivalTo;
                Get.DepartureFrom = depart = bookingRecordViewModel.DepartureFrom;
                Get.TranvelPrice = travel = _booking.GetDepartAndArival(depart, Arival);
                Get.TotalAmount = _booking.TotalAmount(travel, bookAmount, specialAmount, TicketAmount);
            }
            await _booking.UpdateByAsync(Get);
            return RedirectToAction(nameof(Index1));
            // else if (Get.TicketType == "Reqular" && bookingRecordViewModel.TicketType == "VIP")
            //{
            //     Get.TicketType = Ticket = bookingRecordViewModel.TicketType;
            //     Get.TicketAmount = TicketAmount = _booking.TicketType(Ticket);
            //     Get.TicketAmount = _Ticket.TicketReduction(TicketAmount);

            //}
            // else if (Get.TicketType == "Reqular" && bookingRecordViewModel.TicketType == "silver")
            // {
            //     Get.TicketType = Ticket = bookingRecordViewModel.TicketType;
            //     Get.TicketAmount = TicketAmount = _booking.TicketType(Ticket);
            //     Get.TicketAmount = _Ticket.TicketReduction(TicketAmount);

            // }
            // else if (Get.TicketType == "Reqular" && bookingRecordViewModel.TicketType == "Gold")
            // {
            //     Get.TicketType = Ticket = bookingRecordViewModel.TicketType;
            //     Get.TicketAmount = TicketAmount = _booking.TicketType(Ticket);
            //     Get.TicketAmount = _Ticket.TicketReduction(TicketAmount);

            // }
            // else if (Get.TicketType == "Silver" && bookingRecordViewModel.TicketType == "VIP")
            // {
            //     Get.TicketType = Ticket = bookingRecordViewModel.TicketType;
            //     Get.TicketAmount = TicketAmount = _booking.TicketType(Ticket);
            //     Get.TicketAmount = _Ticket.TicketReduction(TicketAmount);

            // }
            // else if (Get.TicketType == "Silver" && bookingRecordViewModel.TicketType == "Gold")
            // {
            //     Get.TicketType = Ticket = bookingRecordViewModel.TicketType;
            //     Get.TicketAmount = TicketAmount = _booking.TicketType(Ticket);
            //     Get.TicketAmount = _Ticket.TicketReduction(TicketAmount);

            // }
            // else if (Get.TicketType == "Silver" && bookingRecordViewModel.TicketType == "VIP")
            // {
            //     Get.TicketType = Ticket = bookingRecordViewModel.TicketType;
            //     Get.TicketAmount = TicketAmount = _booking.TicketType(Ticket);
            //     Get.TicketAmount = _Ticket.TicketReduction(TicketAmount);

            // }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ViewModel = _booking.GetById(id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            var Model = new BookViewModel()
            {
                Id = ViewModel.Id,
                BookForOther = ViewModel.BookForOther,
                TicketType = ViewModel.TicketType,
                DepartureFrom = ViewModel.DepartureFrom,
                ArivalTo = ViewModel.ArivalTo,
                SeatNoId = ViewModel.SeatNoId,
                Payment = ViewModel.Payment,
                Bus = ViewModel.Bus,
            };
            return View(Model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (id == 0)
            {
                return NotFound();

            }
            else
            {
                await _booking.DeleteAsyncById(id);
                return RedirectToAction(nameof(Index1));
            }

        }
    }
}
