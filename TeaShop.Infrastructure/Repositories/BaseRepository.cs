using Microsoft.EntityFrameworkCore;
using TeaShop.Domain.Entities;
using TeaShop.Domain.Interfaces;
using TeaShop.Infrastructure.ApplicationDbContext;

namespace TeaShop.Infrastructure.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ProductCategory CreateCategory(ProductCategory category)
        {
            _dataContext.CategoryTable.Add(category);
            _dataContext.SaveChanges();
            return category;
        }

        public CustomerOrder CreateCustomerOrder(CustomerOrder customerOrder)
        {
            _dataContext.OrderTable.Add(customerOrder);
            _dataContext.SaveChanges();
            return customerOrder;
        }

        public AllProducts CreateProduct(AllProducts product)
        {
            _dataContext.ProductsTable.Add(product);
            _dataContext.SaveChanges();
            return product;
        }

        public int DeleteCategory(int id)
        {
            _dataContext.CategoryTable.Where(k => k.Id == id).ExecuteDelete();
            return _dataContext.SaveChanges();
        }

        public int DeleteCustomerOrder(int id)
        {
            _dataContext.OrderTable.Where(k => k.Id == id).ExecuteDelete();
            return _dataContext.SaveChanges();
        }

        public int DeleteProduct(int id)
        {
            _dataContext.ProductsTable.Where(k => k.Id == id).ExecuteDelete();
            return _dataContext.SaveChanges();
        }

        public AllProducts FindProductDetail(int id)
        {
            return _dataContext.ProductsTable.Find(id);
        }

        public int UpdateCategory(int id, ProductCategory category)
        {
            _dataContext.CategoryTable.Where(k => k.Id == id)
                .ExecuteUpdate(l => l
                .SetProperty(m => m.CategoryName, category.CategoryName));
            return _dataContext.SaveChanges();
        }

        public int UpdateCustomerOrder(int id, CustomerOrder customerOrder)
        {
            _dataContext.OrderTable.Where(k => k.Id == id)
               .ExecuteUpdate(l => l
               .SetProperty(m => m.ProductId, customerOrder.ProductId)
               .SetProperty(m => m.Quantity, customerOrder.Quantity)
               .SetProperty(m => m.TotalPrice, customerOrder.TotalPrice)
               .SetProperty(m => m.TotalWithGst, customerOrder.TotalWithGst));
            return _dataContext.SaveChanges();
        }

        public int UpdateProduct(int id, AllProducts product)
        {
            _dataContext.ProductsTable.Where(k => k.Id == id)
                 .ExecuteUpdate(l => l
                 .SetProperty(m => m.Name, product.Name)
                 .SetProperty(m => m.Price, product.Price)
                 .SetProperty(m => m.CategoryId, product.CategoryId));
            return _dataContext.SaveChanges();
        }
    }
}
