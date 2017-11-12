using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.CustomValidation
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }
    }
}