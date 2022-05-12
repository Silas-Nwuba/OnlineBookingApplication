using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingApplication.Models;
using ProjectServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Controllers.AdminControllers
{
    [Authorize]
    public class AdminPayController : Controller
    {
        private readonly IPayment _payment;
        public AdminPayController(IPayment payment)
        {
            _payment = payment;
        }
        public IActionResult Index(int? PageNumber)
        {
            var Get = _payment.CardPayments().Select(pay => new CardPaymentViewModel
            {
                Id = pay.Id,
                CardName = pay.CardName,
                CardNumber = pay.CardNumber,
                ExpireDate = pay.ExpireDate,
                SecurityCode = pay.SecurityCode,
                BookingRecordId = pay.BookingRecordId


            }).ToList();
            int PageSize = 5;

            return View(Pagination<CardPaymentViewModel>.Create(Get,PageNumber ?? 1 , PageSize));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ViewModel = _payment.GetbyId(id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            var Model = new CardPaymentViewModel()
            {
                Id = ViewModel.Id,
                CardName = ViewModel.CardName,
                CardNumber = ViewModel.CardNumber,
                ExpireDate = ViewModel.ExpireDate,
                SecurityCode = ViewModel.SecurityCode,
                
               
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
            await _payment.DeleleById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
