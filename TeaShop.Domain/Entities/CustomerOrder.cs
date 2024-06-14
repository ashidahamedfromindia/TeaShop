using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaShop.Domain.Entities
{
    public class CustomerOrder
    {
        [Key] public int Id { get; set; }


        [ForeignKey("Id")] public int ProductId { get; set; }
        public AllProducts? AllProducts { get; set; }


        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalWithGst { get; set; }

    }
}
