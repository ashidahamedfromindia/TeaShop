using MediatR;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Enums;

namespace TeaShop.Application.Commands.CategoryCommandFolder
{
    public class CategoryCommand : IRequest<ProductCategoryDto>
    {
        public CategoryCommand(Operation operation, ProductCategoryDto categoryCommand)
        {
            _Operation = operation;
            _CategoryCommand = categoryCommand;
        }

        public Operation _Operation { get; }
        public ProductCategoryDto _CategoryCommand { get; }
       
    }
}
