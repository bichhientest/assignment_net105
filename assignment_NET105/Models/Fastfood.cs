using System.ComponentModel.DataAnnotations.Schema;
namespace assignment_NET105.Models
{
    public class Fastfood
    {
        public int FastfoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }


        public ICollection<ComboFastfood> ComboFastfood { get; set; } 

    }
}
