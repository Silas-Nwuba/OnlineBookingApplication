using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEntity;
using ProjectServices;
using ProjectServices.ApIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private readonly ICustomerApi _customer;
        public TestingController(ICustomerApi customer)
        {
            _customer = customer;
        }
        //Get All Customer
        [HttpGet]
       public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customer.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetAction(int Id)
        {
            return await _customer.GetbyId(Id);
        }
        //Post customer
        [HttpPost]
        public async Task<ActionResult<Customer>> Postcustomer(Customer customer)
        {
            return await _customer.CreateAsync(customer);
        }
        //Put Customer
        [HttpPut]
        public async Task<ActionResult> UpdateById(int Id,Customer customer)
        {
            if(Id != customer.Id)
            {
                return BadRequest();
            }
            await _customer.UpdateById(customer);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        { 
            var del = await _customer.GetbyId(id);
            if(del == null)
            {
                return NotFound();
            }
            await _customer.DeleteById(del.Id);
            return NoContent();
        }
    }
}
