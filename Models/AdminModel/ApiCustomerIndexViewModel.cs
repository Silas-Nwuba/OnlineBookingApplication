using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookingApplication.Models.AdminModel
{
    public class ApiCustomerIndexViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "First Name")]
       
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }

       
        public string Age { get; set; }
      
        public string State { get; set; }
       
        [Display(Name = "Phone No")]
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
       
        public string Gender { get; set; }
        
        [Display(Name = "Next of kin Name")]
        public string NextOfKin { get; set; }
       
        public string NextOfKinGender { get; set; }
        
        [Display(Name = "Next of kin Phone No")]
        public string NextofKinPhone { get; set; }
        
        public string NIN { get; set; }
        [Display(Name = "Photo")]
        public string Photo { get; set; }
        public int Total { get; set; }
    }
}
