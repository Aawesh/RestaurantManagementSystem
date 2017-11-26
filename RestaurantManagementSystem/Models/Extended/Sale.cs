using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Models
{

    [MetadataType(typeof(SaleMetadata))]
    public partial class Sale
    {
    }
    public class SaleMetadata
    {
        [Display(Name = "Sales Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}