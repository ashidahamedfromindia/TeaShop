using AutoMapper;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Interfaces.IQueries;
using TeaShop.Infrastructure.ApplicationDbContext;

namespace TeaShop.Infrastructure.Queries
{
    public class SalesReportQueries : ISalesReportQueries
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public SalesReportQueries(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public SalesReportDto GetSalesReport()
        {
            var productQuantities = _dataContext.OrderTable
                                    .GroupBy(order => order.ProductId)
                                    .Select(g => new
                                    {
                                        ProductId = g.Key,
                                        TotalQuantity = g.Sum(order => order.Quantity)
                                    }).AsQueryable();

            var res = new SalesReportDto
            {
                NumberOfOrder = _dataContext.OrderTable.Count(p => p.Id != null),
                MostOrderedDrink = (from order in productQuantities
                                    join product in _dataContext.ProductsTable on order.ProductId equals product.Id
                                    join category in _dataContext.CategoryTable on product.CategoryId equals category.Id
                                    where category.Id == 1 || category.Id == 2
                                    orderby order.TotalQuantity descending
                                    select product.Name).FirstOrDefault(),
                MostOrderdSnack = (from order in productQuantities
                                   join product in _dataContext.ProductsTable on order.ProductId equals product.Id
                                   join category in _dataContext.CategoryTable on product.CategoryId equals category.Id
                                   where category.Id == 3
                                   orderby order.TotalQuantity descending
                                   select product.Name).FirstOrDefault(),
                TotalSaleAmount = _dataContext.OrderTable.Sum(p => p.TotalPrice)

            };
            return res;


        }
    }
}
