using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingApplication.Models;
using OnlineBookingApplication.Models.AdminModel;
using ProjectEntity;
using ProjectServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Controllers.AdminControllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ICustomer _customer;
        private readonly IWebHostEnvironment _hosting;
        public AdminController(ICustomer customer, IWebHostEnvironment webHostEnvironment)
        {
            _customer = customer;
            _hosting = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index1(int? PageNumber)
        {
            var VieModel = _customer.GetAll().Select(cust => new ApiCustomerIndexViewModel()
            {
                Id = cust.Id,
                FullName = cust.FullName,
                Email = cust.Email,
                NIN = cust.NIN,
                Photo = cust.ImageUrl,
                State = cust.State,
               
            }).ToList();
            int PageSize = 5;
            return View(Pagination<ApiCustomerIndexViewModel>.Create(VieModel,PageNumber ?? 1, PageSize));
        }
        [HttpGet]
        public IActionResult GetAction()
        {
            var ViewModel = new ApiCustomerCreateViewModel();
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApiCustomerCreateViewModel customerIndexViewModel)
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
                    return RedirectToAction("Create", "AdminBook",new { id = ViewModel.Id });

                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetUpdate(int Id)
        {
            var ViewModel = _customer.GetAsyncId(Id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            var Model = new CustomerViewModel
            {
                Id = ViewModel.Id,
                LastName = ViewModel.LastName,
                FirstName = ViewModel.FirstName,
                State = ViewModel.State,
                NIN = ViewModel.NIN,
                NextOfKin = ViewModel.NextOfKin,
                NextofKinPhone = ViewModel.NextofKinPhone,
                Email = ViewModel.Email,
                PhoneNumber = ViewModel.PhoneNumber,
                Gender = ViewModel.Gender,
                Age = ViewModel.Age,
            };
            return View(Model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult>Update(CustomerViewModel customerIndexViewModel)
        {
            var ViewModel = _customer.GetAsyncId(customerIndexViewModel.Id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                ViewModel.Id = customerIndexViewModel.Id;
                ViewModel.FirstName = customerIndexViewModel.FirstName;
                ViewModel.LastName = customerIndexViewModel.LastName;
                ViewModel.Gender = customerIndexViewModel.Gender;
                ViewModel.Age = customerIndexViewModel.Age;
                ViewModel.NextOfKin = customerIndexViewModel.NextOfKin;
                ViewModel.NextofKinPhone = customerIndexViewModel.NextofKinPhone;
                ViewModel.PhoneNumber = customerIndexViewModel.PhoneNumber;
                ViewModel.Email = customerIndexViewModel.Email;
                ViewModel.NIN = customerIndexViewModel.NIN;
                ViewModel.State = customerIndexViewModel.State;
              
                if (customerIndexViewModel.Photo != null && customerIndexViewModel.Photo.Length > 0)
                {
                    var UploadDir = @"Image/Customer";
                    var FileName = Path.GetFileNameWithoutExtension(customerIndexViewModel.Photo.FileName);
                    var FileExtension = Path.GetExtension(customerIndexViewModel.Photo.FileName);
                    var WebRootPath = _hosting.WebRootPath;
                    FileName = DateTime.UtcNow.ToString("ddmmyy").ToUpper() + FileName + FileExtension;
                    var path = Path.Combine(WebRootPath, UploadDir, FileName);
                    await customerIndexViewModel.Photo.CopyToAsync(new FileStream(path, FileMode.Create));
                    ViewModel.ImageUrl = "/" + UploadDir + "/" + FileName;
                }
                await _customer.UpdateAsync(ViewModel);
                return RedirectToAction(nameof(Index1));

            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ViewModel = _customer.GetAsyncId(id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            var Model = new ApiCustomerIndexViewModel()
            {
                Id = ViewModel.Id,
                FullName = ViewModel.FullName,
                Photo = ViewModel.ImageUrl,
                NIN = ViewModel.NIN,
                Email = ViewModel.Email,
                State = ViewModel.State,
               
            };
            return View(Model);
        }
        [HttpPost]
        public async Task<IActionResult>Delete(ApiCustomerIndexViewModel apiCustomerIndexViewModel)
        {
            if(apiCustomerIndexViewModel == null)
            {
                return NotFound();

            }
            else
            {
                await _customer.DeleteAsync(apiCustomerIndexViewModel.Id);
                return RedirectToAction(nameof(Index1));
            }

        }
    }
}
