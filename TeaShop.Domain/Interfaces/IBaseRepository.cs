using TeaShop.Domain.Entities;

namespace TeaShop.Domain.Interfaces
{
    public interface IBaseRepository
    {
        ProductCategory CreateCategory(ProductCategory category);
        AllProducts CreateProduct(AllProducts product);
        CustomerOrder CreateCustomerOrder(CustomerOrder customerOrder);


        int UpdateCategory(int id, ProductCategory category);
        int UpdateProduct(int id, AllProducts product);
        int UpdateCustomerOrder(int id, CustomerOrder customerOrder);

        int DeleteCategory(int id);
        int DeleteProduct(int id);
        int DeleteCustomerOrder(int id);


        AllProducts FindProductDetail(int id);

    }
}
