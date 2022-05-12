using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingApplication.Models;
using ProjectEntity;
using ProjectServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Controllers.AdminControllers
{
    [Authorize]
    public class AdminPaymentController : Controller
    {
        private readonly ITransactionAmount _transaction;
        private readonly ICardPayment _CardPayment;
        private readonly IBookingRecord _Booking;
        public AdminPaymentController(ICardPayment cardPayment1, ITransactionAmount transactionAmount, IBookingRecord bookingRecord)
        {
            _Booking = bookingRecord;
            _CardPayment = cardPayment1;
            _transaction = transactionAmount;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            try
            {
                var Model = _Booking.GetById(id);
                if (Model == null)
                {
                    return NotFound();
                }

                var Viewmode = new CardPaymentViewModel
                {


                    BookingRecordId = Model.Id,

                };
                return View(Viewmode);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CardPaymentCreateViewModel cardPaymentCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var Card = new CardPayment
                {
                    Id = cardPaymentCreateViewModel.Id,
                    BookingRecordId = cardPaymentCreateViewModel.BookingRecordId,
                    CardName = cardPaymentCreateViewModel.CardName,
                    CardNumber = cardPaymentCreateViewModel.CardNumber,
                    ExpireDate = cardPaymentCreateViewModel.ExpireDate,
                    SecurityCode = cardPaymentCreateViewModel.SecurityCode,
                };
                await _CardPayment.CreateAsync(Card);
                return RedirectToAction("Index1","AdminBook");

            }
            return View();
        }
    }
}

