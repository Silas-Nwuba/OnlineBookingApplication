using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingApplication.Models;
using ProjectEntity;
using ProjectServices;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly IBookingRecord _Booking;
      
        public TransactionController(ITransactionAmount transactionAmount, IBookingRecord bookingRecord)
        {
            _Booking = bookingRecord;

        }
        public IActionResult Index(int id)
        {
            try
            {
                var GetById = _Booking.GetById(id);
                if (GetById == null)
                {
                    return NotFound();
                }
                var ViewModel = new TransactionIndexViewModel
                {
                    Id = id,
                    SpecialRequest = GetById.SpecialRequest,
                    BookFother = GetById.BookForOther,
                    TicketType = GetById.TicketType,
                    DepatureFrom = GetById.DepartureFrom,
                    ArivalTo = GetById.ArivalTo,
                    TicketAmount = GetById.TicketAmount,
                    TravelPrice = GetById.TranvelPrice,
                    BookAmount = GetById.BookAmount,
                    SpecialAmount = GetById.SpecialAmount,
                    TotalAmount = GetById.TotalAmount,


                };
                return View(ViewModel);
            }
            catch (System.Exception)
            {

                throw;
            }
           
           

        }
    
    }
}
