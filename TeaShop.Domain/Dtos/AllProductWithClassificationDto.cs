namespace TeaShop.Domain.Dtos
{
    public class AllProductWithClassificationDto
    {
        public int CategoryId { get; set; }
        public List<AllProductsDto>? Products { get; set; }
    }
}
