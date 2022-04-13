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
            var GetBy = _customer.GetAsyncId(id);
            var ViewModel = new BookingRecordViewModel
            {
                FullName = GetBy.FullName,
                NIN = GetBy.NIN,
                Id = GetBy.Id,
            };
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingCreateViewModel bookingRecordViewModel)
        {
            if (ModelState.IsValid)
            {
                var ViewModel = new BookingRecord()
                {
                    Id = bookingRecordViewModel.Id,
                    SeatNo = bookingRecordViewModel.SeatNo,
                    TicketId = bookingRecordViewModel.TicketId,
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
                };
                await _booking.CreateAsync(ViewModel);
            }
            return View();
        }
    }
}
