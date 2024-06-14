using AutoMapper;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Interfaces.IQueries;
using TeaShop.Infrastructure.ApplicationDbContext;

namespace TeaShop.Infrastructure.Queries
{
    public class ProductQueries : IProductQueries
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ProductQueries(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public List<ProductCategoryDto> GetAllCategories()
        {
            return _mapper.Map<List<ProductCategoryDto>>(_dataContext.CategoryTable.ToList());
        }

        public List<AllProductsDto> GetAllProducts()
        {
            return _mapper.Map<List<AllProductsDto>>(_dataContext.ProductsTable.ToList());
        }

        public ProductCategoryDto GetCategory(int id)
        {
            return _mapper.Map<ProductCategoryDto>(_dataContext.CategoryTable.FirstOrDefault(v => v.Id == id));
        }

        public AllProductsDto GetProduct(int id)
        {
            return _mapper.Map<AllProductsDto>(_dataContext.ProductsTable.FirstOrDefault(v => v.Id == id));
        }
    }
}
