using System.ComponentModel.DataAnnotations;

namespace TeaShop.Domain.Entities
{
    public class ProductCategory
    {
        [Key] public int Id { get; set; }
        public string? CategoryName { get; set; }
    }
}
