using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaShop.Domain.Entities
{
    public class AllProducts
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        [ForeignKey("Id")] public int CategoryId { get; set; }
        public ProductCategory? Category { get; set; }

    }
}
