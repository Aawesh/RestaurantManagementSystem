using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using RestaurantManagementSystem.CustomValidation;
//namespace RestaurantManagementSystem.Models.Extended
namespace RestaurantManagementSystem.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        public string ConfirmPassword { get; set; }

        public bool TermsAndConditions { get; set; }

    }
    
    public class UserMetadata
    {
        [Display(Name ="First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="First name required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number required")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }

        [Display(Name ="Email ID")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required(AllowEmptyStrings =false, ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm password and password do not match")]
        public string ConfirmPassword { get; set; }

        [MustBeTrue(ErrorMessage = "You have to accept the terms and conditions!")]
        public bool TermsAndConditions { get; set; }
    }
}