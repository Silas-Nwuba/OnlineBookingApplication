using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Models.AdminModel
{
    public class ApiCustomerCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name field is required")]
        [StringLength(100)]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z][a-zA-Z""\s-]*$", ErrorMessage = "Invalid Input format")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[A-Z][a-zA-Z""\s-]*$", ErrorMessage = "Invalid Input format")]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(100)]
        public string FullName => FirstName + " " + LastName;

        [RegularExpression(@"^[1-9]{1}[0-9]{1}$", ErrorMessage = "incorrect input of Age")]
        public string Age { get; set; }
        [Required]
        public string State { get; set; }
        [Required(ErrorMessage = "Phone number field required")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "phone number is invalid")]
        [Display(Name = "Phone No")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[A-Z][a-zA-Z""/s-]*$", ErrorMessage = "Invalid input Format")]
        [Display(Name = "Next of kin Name")]
        public string NextOfKin { get; set; }
        [Required]
        public string NextOfKinGender { get; set; }
        [Required(ErrorMessage = "Phone number field required")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "phone number is invalid")]
        [Display(Name = "Next of kin Phone No")]
        public string NextofKinPhone { get; set; }
        [Required(ErrorMessage = "NiN field is required")]
        [StringLength(100)]
        [RegularExpression(@"^[1-9]{4}\s[0-9]{4}\s[0-9]{4}\s[0-9]{4}$", ErrorMessage = "Invalid National identity Number")]
        public string NIN { get; set; }
        [Display(Name = "Photo")]
        [Required(ErrorMessage = "Photo Field is required")]
        public IFormFile ImageUrl { get; set; }
    }
}
