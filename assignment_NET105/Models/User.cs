using System.ComponentModel.DataAnnotations;
namespace assignment_NET105.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter Username.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Please enter Email address.")]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please select a role.")]
        public string Role { get; set; }

        public ICollection<OrderCombo> OrderCombos { get; set; }
        public ICollection<OrderFastfood> OrderFastfoods { get; set; }
    }
}
