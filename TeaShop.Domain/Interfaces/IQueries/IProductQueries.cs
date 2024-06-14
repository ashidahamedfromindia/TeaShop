using TeaShop.Domain.Dtos;

namespace TeaShop.Domain.Interfaces.IQueries
{
    public interface IProductQueries
    {
        List<AllProductsDto> GetAllProducts();
        AllProductsDto GetProduct(int id);
        List<ProductCategoryDto> GetAllCategories();
        ProductCategoryDto GetCategory(int id);


    }
}
