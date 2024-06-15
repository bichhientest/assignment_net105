using System.ComponentModel.DataAnnotations.Schema;
namespace assignment_NET105.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int FastfoodId { get; set; }
        public int Quatity { get; set; }
        public string TotalAmount { get; set; }

        [ForeignKey("OrderId")]
        public OrderFastfood Orders { get; set; }

        [ForeignKey("FastfoodId")]
        public Fastfood Fastfood { get; set; }
    }
}
