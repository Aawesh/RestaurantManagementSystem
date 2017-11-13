using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using RestaurantManagementSystem.CustomValidation;

namespace RestaurantManagementSystem.Models
{

    [MetadataType(typeof(FoodMetadata))]
    public partial class Food
    {
    }
    public class FoodMetadata
    {
        [Display(Name = "Food Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Food name required")]
        public string Name { get; set; }

        [Display(Name = "Amount")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount required")]
        public string Amount { get; set; }

        [Display(Name = "Price")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Price required")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Food Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Food Type required")]
        public string FoodType { get; set; }

        [Display(Name = "Bought Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BoughtDate { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Manufactured Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ManufacturedDate { get; set; }
    }
}