using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingApplication.Models;
using ProjectEntity;
using ProjectServices;

namespace OnlineBookingApplication.Controllers
{

    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;
        private readonly IWebHostEnvironment _hosting;
        private readonly IBookingRecord _bookingRecord;
        public CustomerController(ICustomer customer,IBookingRecord bookingRecord,IWebHostEnvironment webHostEnvironment)
        {
            _hosting = webHostEnvironment;
            _customer = customer;
            _bookingRecord = bookingRecord;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var ViewModel = new CustomerIndexViewModel();
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerIndexViewModel customerIndexViewModel)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new Customer
                {
                    Id = customerIndexViewModel.Id,
                    FirstName = customerIndexViewModel.FirstName,
                    LastName = customerIndexViewModel.LastName,
                    FullName = customerIndexViewModel.FullName,
                    Email = customerIndexViewModel.Email,
                    Gender = customerIndexViewModel.Gender,
                    PhoneNumber = customerIndexViewModel.PhoneNumber,
                    Age = customerIndexViewModel.Age,
                    NIN = customerIndexViewModel.NIN,
                    NextOfKin = customerIndexViewModel.NextOfKin,
                    NextofKinPhone = customerIndexViewModel.NextofKinPhone,
                    State = customerIndexViewModel.State,
                   
                };
                if (customerIndexViewModel.ImageUrl != null && customerIndexViewModel.ImageUrl.Length > 0)
                {
                    var UploadDir = @"Image/Customer";
                    var FileName = Path.GetFileNameWithoutExtension(customerIndexViewModel.ImageUrl.FileName);
                    var FileExtension = Path.GetExtension(customerIndexViewModel.ImageUrl.FileName);
                    var WebRootPath = _hosting.WebRootPath;
                    FileName = DateTime.UtcNow.ToString("ddmmyy").ToUpper() + FileName + FileExtension;
                    var path = Path.Combine(WebRootPath, UploadDir, FileName);
                    await customerIndexViewModel.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    ViewModel.ImageUrl = "/" + UploadDir + "/" + FileName;
                    await _customer.CreateAsync(ViewModel);
                    return RedirectToAction("Index", "Booking",new { id = ViewModel.Id });

                }
            }
            return View();
        }
     
    }

   
}
                

 
