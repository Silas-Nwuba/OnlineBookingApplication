using Microsoft.AspNetCore.Mvc;
using OnlineBookingApplication.Models;
using ProjectEntity;
using ProjectServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Controllers
{
    public class CardPaymentController : Controller
    {
        private readonly IBookingRecord _booking;
        private readonly ICardPayment _CardPayment;
        public CardPaymentController(IBookingRecord booking , ICardPayment cardPayment1)
        {
            _CardPayment = cardPayment1;
            _booking = booking;
        }
     
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                //var Model = _booking.GetById(Id);
                var Viewmode = new CardPaymentViewModel();
               
                return View(Viewmode);
            }
            catch (Exception)
            {

                throw;
            }
          
           

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public IActionResult Create(CardPaymentViewModel cardPaymentViewModel)
        ////{
        //    if (ModelState.IsValid)
        //    {
        //        var View = new CardPayment
        //        {
        //            Id = cardPaymentViewModel.Id,
        //            BookingRecordId = cardPaymentViewModel.BookingRecordId,
        //            CardName = cardPaymentViewModel.CardName,
        //            CardNumber = cardPaymentViewModel.CardNumber,
        //            ExpireDate = cardPaymentViewModel.ExpireDate,
        //            SecurityCode = cardPaymentViewModel.SecurityCode,
        //        };
        //        await _
        //    }
        //}
    }
}
