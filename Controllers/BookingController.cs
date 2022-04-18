using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProjectServices;
using ProjectEntity;
using OnlineBookingApplication.Models;

namespace OnlineBookingApplication.Controllers
{

    public class BookingController : Controller
    {
        private readonly IBookingRecord _booking;
        private readonly ICustomer _customer;

        public BookingController(IBookingRecord bookingRecord, ICustomer customer)
        {
            _booking = bookingRecord;
            _customer = customer;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            ViewBag.SeatNoId = _booking.GetSeatNo();
            var GetBy = _customer.GetAsyncId(id);
            var ViewModel = new BookingRecordViewModel
            {
                FullName = GetBy.FullName,
                NIN = GetBy.NIN,
                CustomerId = GetBy.Id,
               
            };
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(BookingCreateViewModel bookingRecordViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ViewModel = new BookingRecord()
                    {
                        Id = bookingRecordViewModel.Id,
                        CustomerId = bookingRecordViewModel.CustomerId,
                        Date = bookingRecordViewModel.Date,
                        DepartureFrom = bookingRecordViewModel.DepartureFrom,
                        ArivalTo = bookingRecordViewModel.ArivalTo,
                        Payment = bookingRecordViewModel.Payment,
                        FullName = bookingRecordViewModel.FullName,
                        NiN = bookingRecordViewModel.NIN,
                        Bus = bookingRecordViewModel.Bus,
                        TicketType = bookingRecordViewModel.TicketType,
                        SpecialRequest = bookingRecordViewModel.SpecialRequest,
                        BookForOther = bookingRecordViewModel.BookForOther,
                        SeatNoId = bookingRecordViewModel.SeatNoId,
                        //SeatNumber = _booking.GetById(bookingRecordViewModel.SeatNoId).SeatNumber,
                    };
                    await _booking.CreateAsync(ViewModel);
                    return RedirectToAction("Index", "Transaction", new { id = ViewModel.Id });

                }
                catch (System.Exception exp)
                {

                    throw exp;
                }
            };
            ViewBag.SeatNoId = _booking.GetSeatNo();
            return View();
        }
    }
}
