using Microsoft.AspNetCore.Mvc;
using OnlineBookingApplication.Models;
using ProjectEntity;
using ProjectServices;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionAmount _transactionAmount;
        private readonly IBookingRecord _Booking;
        private decimal SpecialRequest;
        private decimal BookForOther;
        private decimal TicketType;

        public TransactionController(ITransactionAmount transactionAmount, IBookingRecord bookingRecord)
        {
            _transactionAmount = transactionAmount;
            _Booking = bookingRecord;

        }
        public IActionResult Index(int id)
        {
            var GetById = _Booking.GetById(id);
            var ViewModel = new TransactionIndexViewModel
            {
                FullName = GetById.FullName,
                NiN = GetById.NiN,
                SeatNo = GetById.SeatNoId,
                BookingRecordId =GetById.Id,
                DepartureFrom = GetById.DepartureFrom,
                ArivalTo = GetById.ArivalTo,
                Date = GetById.Date,
                Special = GetById.SpecialRequest.ToString(),
                Book = GetById.BookForOther.ToString(),
                Ticket = GetById.TicketType.ToString(),
                SpecialRequest = SpecialRequest = _Booking.SpecialRequest(GetById.Id),
                TicketType = TicketType = _Booking.TicketType(GetById.Id),
                BookForOther = BookForOther = _Booking.BookForOther(GetById.Id),
                TotalAmount = _transactionAmount.TotalAmount(SpecialRequest, BookForOther, TicketType),
            };
            return View(ViewModel);
        }
        public async Task<IActionResult>Create(TransactionCreateViewModel transactionCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var ViewModel = new TransactionAmount()
                {
                    Id = transactionCreateViewModel.Id,
                    BookingRecordId = transactionCreateViewModel.BookingRecordId,
                    SpecialRequest = transactionCreateViewModel.SpecialRequest,
                    BookForOther = transactionCreateViewModel.BookForOther,
                    TicketType = transactionCreateViewModel.TicketType,
                    TotalAmount = transactionCreateViewModel.TotalAmount,

                };
                await _transactionAmount.CreateAsync(ViewModel);
            }
            return View();
        }
      
    }
}
