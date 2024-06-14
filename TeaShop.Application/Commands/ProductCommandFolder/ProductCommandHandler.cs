using AutoMapper;
using MediatR;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Entities;
using TeaShop.Domain.Enums;
using TeaShop.Domain.Interfaces;

namespace TeaShop.Application.Commands.ProductCommandFolder
{
    public class ProductCommandHandler : IRequestHandler<ProductCommand, AllProductsDto>
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;

        public ProductCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<AllProductsDto> Handle(ProductCommand request, CancellationToken cancellationToken)
        {
            AllProducts allProducts;
            switch (request.Operation)
            {
                case Operation.Create:
                    allProducts = new AllProducts
                    {
                        Id = request.AllProducts.Id,
                        Name = request.AllProducts.Name,
                        CategoryId = request.AllProducts.CategoryId,
                        Price = request.AllProducts.Price
                    };
                    var newProduct = _baseRepository.CreateProduct(allProducts);
                    return _mapper.Map<AllProductsDto>(newProduct);
                case Operation.Update:
                    var bProduct = new AllProducts
                    {
                        Name = request.AllProducts.Name,
                        CategoryId = request.AllProducts.CategoryId,
                        Price = request.AllProducts.Price
                    };
                    var editProduct = _baseRepository.UpdateProduct(request.AllProducts.Id, bProduct);
                    return _mapper.Map<AllProductsDto>(editProduct);

                case Operation.Delete:
                    _baseRepository.DeleteProduct(request.AllProducts.Id);
                    return null;

                default:
                    throw new InvalidOperationException("Invalid operation type.");
            }
        }
    }
}
