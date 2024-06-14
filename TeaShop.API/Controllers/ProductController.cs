using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Application.Commands.CategoryCommandFolder;
using TeaShop.Application.Commands.ProductCommandFolder;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Enums;
using TeaShop.Domain.Interfaces.IQueries;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProductQueries _productQueries;

        public ProductController(IMediator mediator, IProductQueries productQueries)
        {
            _mediator = mediator;
            _productQueries = productQueries;
        }
        [HttpGet("ALL CATEGORIES")]
        public List<ProductCategoryDto> GetCategories()
        {
            return _productQueries.GetAllCategories();
        }
        [HttpGet("FIND CATEGORY BY ID")]
        public ProductCategoryDto GetCategories(int id)
        {
            return _productQueries.GetCategory(id);
        }
        [HttpGet("FIND PRODUCT BY ID")]
        public AllProductsDto GetProduct(int id)
        {
            return _productQueries.GetProduct(id);
        }
        [HttpGet("ALL PRODUCTS")]
        public List<AllProductsDto> GetProducts()
        {
            return _productQueries.GetAllProducts();
        }

        [HttpPost("CREATE NEW CATEGORY")]
        public ActionResult PostCreateCategory(ProductCategoryDto categoryDto)
        {
            var command = new CategoryCommand(Operation.Create, categoryDto);
            var newCAt = _mediator.Send(command);
            return Ok(newCAt);
        }
        [HttpPost("CREATE NEW PRODUCT")]
        public ActionResult PostCreateProduct(AllProductsDto productsDto)
        {
            var command = new ProductCommand(Operation.Create, productsDto);
            var newPro = _mediator.Send(command);
            return Ok(newPro);
        }
        [HttpPut("EDIT CATEGORY{id}")]
        public ActionResult PutEditCategory(int id, ProductCategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest();
            }
            var command = new CategoryCommand(Operation.Update, categoryDto);
            _mediator.Send(command);
            return NoContent();
        }
        [HttpPut("EDIT PRODUCT{id}")]
        public ActionResult PutEditProduct(int id, AllProductsDto productsDto)
        {
            if (id != productsDto.Id)
            {
                return BadRequest();
            }
            var command = new ProductCommand(Operation.Update, productsDto);
            _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("DELETE CATEGORY{id}")]
        public ActionResult DeleteCategory(int id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var DeleteId = new ProductCategoryDto { Id = id };
            var command = new CategoryCommand(Operation.Delete, DeleteId);
            _mediator.Send(command._CategoryCommand.Id);
            return NoContent();

        }
        [HttpDelete("DELETE PRODUCT{id}")]
        public ActionResult DeleteProduct(int id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var DeleteId = new AllProductsDto { Id = id };
            var command = new ProductCommand(Operation.Delete, DeleteId);
            _mediator.Send(command.AllProducts.Id);
            return NoContent();

        }

    }
}
