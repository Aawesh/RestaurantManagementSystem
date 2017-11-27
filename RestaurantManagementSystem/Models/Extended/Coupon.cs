using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace RestaurantManagementSystem.Models
{
    [MetadataType(typeof(CouponMetadata))]
    public partial class Coupon
    {
    }

    public class CouponMetadata
    {
        [Display(Name = "Discount Percent (%)")]
        [Required(ErrorMessage = "Select Discount percent")]
        public string DiscountPercent { get; set; }

        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExpiryDate { get; set; }
    }
}