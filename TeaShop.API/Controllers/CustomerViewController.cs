using Microsoft.AspNetCore.Mvc;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Interfaces.IQueries;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerViewController : ControllerBase
    {

        private readonly ICustomerQueries _customerQueries;

        public CustomerViewController(ICustomerQueries customerQueries)
        {

            _customerQueries = customerQueries;
        }
        [HttpGet("Enter 1 for Hotdrinks List,Enter 2 for CoolDrinks List & Enter 3 for Snacks List")]
        public List<ProductListWithCategoryDto> GetAllProductByCategory(int x)
        {
            return _customerQueries.GetProductByCategory(x);

        }
        [HttpGet("All Product Categorywise")]
        public List<AllProductWithClassificationDto> GetAlltheProductsWithClass()
        {
            return _customerQueries.GetAllProductsWithClass();

        }
    }
}
