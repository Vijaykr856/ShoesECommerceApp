using System.ComponentModel.DataAnnotations;

namespace ShoesECommerceApp.Models
{
    public class Shoes
    {
        [Key]
        public int Id { get; set; }

        public int Shoessize { get; set; }
        public string Shoesbrand { get; set; }

        public int Shoesprice { get; set; }
        public byte[] Shoespic { get; set; }
    }
}
