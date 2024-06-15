using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace assignment_NET105.Models
{
    public class OrderCombo
    {
        public int OrderComboId { get; set; }
        public int UserId { get; set; }
        public int ComboId { get; set; }


        [DataType(DataType.Date)]
        public DateTime Orderdate { get; set; }

        public int Quatity { get; set; }

        public string TotalAmount { get; set; }

        public string Status { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Combo Combo { get; set; }
    }
}
