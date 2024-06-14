using AutoMapper;
using MediatR;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Entities;
using TeaShop.Domain.Interfaces;

namespace TeaShop.Application.Commands.CategoryCommandFolder
{
    public class CategoryCommandHandler : IRequestHandler<CategoryCommand, ProductCategoryDto>
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;

        public CategoryCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ProductCategoryDto> Handle(CategoryCommand request, CancellationToken cancellationToken)
        {
            ProductCategory category;
            switch (request._Operation)
            {
                case Domain.Enums.Operation.Create:
                    category = new ProductCategory
                    {
                        CategoryName = request._CategoryCommand.CategoryName
                    };
                    var newCategory = _baseRepository.CreateCategory(category);
                    return _mapper.Map<ProductCategoryDto>(newCategory);

                case Domain.Enums.Operation.Update:
                    category = new ProductCategory
                    {
                        CategoryName = request._CategoryCommand.CategoryName
                    };
                    var editCategory = _baseRepository.UpdateCategory(request._CategoryCommand.Id, category);
                    return _mapper.Map<ProductCategoryDto>(editCategory);

                case Domain.Enums.Operation.Delete:
                    _baseRepository.DeleteCategory(request._CategoryCommand.Id);
                    return null;

                default:
                    throw new InvalidOperationException("Invalid operation type.");
            }
        }
    }
}
