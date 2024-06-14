namespace TeaShop.Domain.Dtos
{
    public class CustomerOrderDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalWithGst { get; set; }
    }
}
