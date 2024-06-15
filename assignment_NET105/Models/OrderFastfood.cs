using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace assignment_NET105.Models
{
    public class OrderFastfood
    {
        public int OrderFastfoodId { get; set; }
        public int UserId { get; set; }


        [DataType(DataType.Date)]
        public DateTime Orderdate { get; set; }

        public int Quatity { get; set; }

        public string TotalAmount { get; set; }

        public string Status { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
