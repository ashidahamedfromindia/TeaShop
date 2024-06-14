using TeaShop.Domain.Dtos;

namespace TeaShop.Domain.Interfaces.IQueries
{
    public interface ICustomerQueries
    {
        List<CustomerOrderDto> GetAllOrder();
        CustomerOrderDto GetCustomerOrder(int id);


        List<ProductListWithCategoryDto> GetProductByCategory(int x);
        List<AllProductWithClassificationDto> GetAllProductsWithClass();
    }
}
