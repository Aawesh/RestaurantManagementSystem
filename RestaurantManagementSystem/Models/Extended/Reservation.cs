using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Models
{

    [MetadataType(typeof(ReservationMetadata))]
    public partial class Reservation
    {
    }
    public class ReservationMetadata
    {
        [Required]
        [Display(Name = "Number of Person")]
        [Range(0, 10, ErrorMessage = "Please enter valid integer Number")]
        public int Persons { get; set; }

        [Display(Name = "Reservation date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [Display(Name = "From Time")]
        public string FromTime { get; set; }

        [Display(Name = "To Time")]
        public string ToTime { get; set; }

        [Display(Name = "Chicken Sandwich")]
        public string Menu1 { get; set; }

        [Display(Name = "Chicken Nuggets")]
        public string Menu2 { get; set; }

        [Display(Name = "Cheese Pizza")]
        public string Menu3{ get; set; }

        [Display(Name = "Boneless Chicken")]
        public string Menu4 { get; set; }

        [Display(Name = "Ham Burger")]
        public string Menu5 { get; set; }
    }
}
