using MediatR;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Enums;

namespace TeaShop.Application.Commands.ProductCommandFolder
{
    public class ProductCommand : IRequest<AllProductsDto>
    {
        public ProductCommand(Operation operation, AllProductsDto allProducts)
        {
            Operation = operation;
            AllProducts = allProducts;
        }

        public Operation Operation { get; }
        public AllProductsDto AllProducts { get; }
    }
}
