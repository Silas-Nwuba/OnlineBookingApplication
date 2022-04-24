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
        private readonly ITransactionAmount _transactionAmount;
        private string depart;
        private string Arival;
        private string special;
        private string Ticket;
        private string book;
        private decimal Price;
        private decimal SpeaialAmount;
        private decimal TicketAmount;
        private decimal BookingAmount;

        public BookingController(IBookingRecord bookingRecord,ICustomer customer,ITransactionAmount transactionAmount)
        {
            _transactionAmount = transactionAmount;
            _booking = bookingRecord;
            _customer = customer;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            ViewBag.SeatNoId = _booking.GetSeatNo();
            var GetBy = _customer.GetAsyncId(id);
            if(GetBy == null)
            {
                return NotFound();
            }
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
                        DepartureFrom = depart = bookingRecordViewModel.DepartureFrom,
                        ArivalTo = Arival = bookingRecordViewModel.ArivalTo,
                        Payment = bookingRecordViewModel.Payment,
                        FullName = bookingRecordViewModel.FullName,
                        NiN = bookingRecordViewModel.NIN,
                        Bus = bookingRecordViewModel.Bus,
                        TicketType = Ticket = bookingRecordViewModel.TicketType,
                        SpecialRequest = special = bookingRecordViewModel.SpecialRequest,
                        BookForOther = book = bookingRecordViewModel.BookForOther,
                        SeatNoId = bookingRecordViewModel.SeatNoId,
                        TranvelPrice = Price = _booking.GetDepartAndArival(depart, Arival),
                        SpecialAmount = SpeaialAmount = _booking.GetSpecial(special),
                        TicketAmount = TicketAmount = _booking.TicketType(Ticket),
                        BookAmount = BookingAmount = _booking.BookForOther(book),
                        TotalAmount =_booking.TotalAmount(Price, SpeaialAmount, TicketAmount, BookingAmount),
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
