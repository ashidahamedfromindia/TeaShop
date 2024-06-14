namespace TeaShop.Domain.Dtos
{
    public class SalesReportDto
    {

        public int NumberOfOrder { get; set; }
        public string? MostOrderedDrink { get; set; }
        public string? MostOrderdSnack { get; set; }
        public decimal? TotalSaleAmount { get; set; }
        //public MostOrderedProductDto TopSellingProduct { get; set; }
    }
}
