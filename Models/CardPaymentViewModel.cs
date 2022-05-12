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
        [RegularExpression(@"^[a-zA-z\s-]*$", ErrorMessage ="Invalid input of Card Name")]
        [MinLength(3,ErrorMessage ="Card Name Should Atleast more 3 character")]
        [Display(Name ="Card Name")]
        public string CardName { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]{4}\s[0-9]{4}\s[0-9]{4}\s[0-9]{4}$",ErrorMessage ="Invalid Card Number")]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }
        [Required]
        [Display(Name = "Expire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/YY}",ApplyFormatInEditMode =true)]
        public DateTime ExpireDate { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]{3}$",ErrorMessage ="Security code should be three digit Number")]
        [Display(Name = "Security Code")]
        [DataType(DataType.Password)]
        public string SecurityCode { get; set; }
    }
}
