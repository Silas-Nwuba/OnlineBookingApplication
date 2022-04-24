using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProjectEntity;

namespace OnlineBookingApplication.Models
{
    public class CardPaymentViewModel
    {
        public int Id { get; set; }
        public BookingRecord BookingRecord { get; set; }
        [Required]
        public int BookingRecordId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]{3,50}[a-zA-z\s]*$", ErrorMessage ="Name Should be Aleast more than 3 character")]
        [Display(Name ="Card Name")]
        public string CardName { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]{4}\s[0-9]{4}\s[0-9]{4}\s[0-9]{4}$",ErrorMessage ="Invalid Card Number")]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }
        [Required]
        [Display(Name = "Expire Date")]
        public DateTime ExpireDate { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]{3,3}$",ErrorMessage ="Security code should be three digit Number")]
        [Display(Name = "Security Code")]
        public string SecurityCode { get; set; }
    }
}
