using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEntity;
using ProjectServices.ApIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingApi _booking;
        public BookingController(IBookingApi booking)
        {
            _booking = booking;
        }
        //Get All booking
        [HttpGet]
        public async Task<IEnumerable<BookingRecord>> GetCustomers()
        {
            return await _booking.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingRecord>> GetAction(int Id)
        {
            return await _booking.GetbyId(Id);
        }
        //Post booking
        [HttpPost]
        public async Task<ActionResult<BookingRecord>> Postcustomer(BookingRecord booking)
        {
            return await _booking.CreateAsync(booking);
        }
        //Put Customer
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateById(int Id, BookingRecord booking)
        {
            if (Id != booking.Id)
            {
                return BadRequest();
            }
            await _booking.UpdateById(booking);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var del = await _booking.GetbyId(id);
            if (del == null)
            {
                return NotFound();
            }
            await _booking.DeleteById(del.Id);
            return NoContent();
        }
    }
}

