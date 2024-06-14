using MediatR;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Enums;

namespace TeaShop.Application.Commands.OrderCommandFolder
{
    public class OrderCommand : IRequest<CustomerOrderDto>
    {
        public OrderCommand(Operation operation, CustomerOrderforPostDto customerOrder)
        {
            Operation = operation;
            CustomerOrder = customerOrder;
        }

        public Operation Operation { get; }
        public CustomerOrderforPostDto CustomerOrder { get; }
    }
}
