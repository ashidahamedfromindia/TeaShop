using AutoMapper;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Entities;
using TeaShop.Domain.Interfaces.IQueries;
using TeaShop.Infrastructure.ApplicationDbContext;

namespace TeaShop.Infrastructure.Queries
{
    public class CustomerQueries : ICustomerQueries
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CustomerQueries(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public List<CustomerOrderDto> GetAllOrder()
        {
            return _mapper.Map<List<CustomerOrderDto>>(_dataContext.OrderTable.ToList());
        }

        public List<ProductListWithCategoryDto> GetProductByCategory(int x)
        {
            var CheckParameter = x;

            var ListOfSnacks = (from AllProducts in _dataContext.ProductsTable
                                where AllProducts.CategoryId == x
                                select new AllProductsDto
                                {
                                    Name = AllProducts.Name,
                                    Price = AllProducts.Price,
                                }).ToList();
            return _mapper.Map<List<ProductListWithCategoryDto>>(ListOfSnacks);
        }

        public CustomerOrderDto GetCustomerOrder(int id)
        {
            return _mapper.Map<CustomerOrderDto>(_dataContext.OrderTable.FirstOrDefault(k => k.Id == id));
        }

        public List<AllProductWithClassificationDto> GetAllProductsWithClass()
        {
            var AllListByGroup = (from Product in _dataContext.ProductsTable
                                  group new
                                  {
                                      Product.Name,
                                      Product.Price,

                                  } by Product.CategoryId into grouped
                                  select new AllProductWithClassificationDto
                                  {
                                      CategoryId = grouped.Key,
                                      Products = grouped.Select(k => new AllProductsDto
                                      {
                                          Price = k.Price,
                                          Name = k.Name
                                      }).ToList()

                                  }
                                ).ToList();
            return _mapper.Map<List<AllProductWithClassificationDto>>(AllListByGroup);
        }
    }
}
