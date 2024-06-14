using AutoMapper;
using MediatR;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Entities;
using TeaShop.Domain.Interfaces;

namespace TeaShop.Application.Commands.OrderCommandFolder
{
    public class OrderCommandHandler : IRequestHandler<OrderCommand, CustomerOrderDto>
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;

        public OrderCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<CustomerOrderDto> Handle(OrderCommand request, CancellationToken cancellationToken)
        {
            CustomerOrder customerOrder; AllProducts allProducts;


            var ProductById = _baseRepository.FindProductDetail(request.CustomerOrder.ProductId);
            var totalPrice = request.CustomerOrder.Quantity * ProductById.Price ?? 0m;
            var gstrate = 0.18m;
            var totalWithGst = totalPrice + (totalPrice * gstrate);

            switch (request.Operation)
            {
                case Domain.Enums.Operation.Create:

                    var newOrderAssign = new CustomerOrder
                    {
                        ProductId = request.CustomerOrder.ProductId,
                        Quantity = request.CustomerOrder.Quantity,
                        TotalPrice = totalPrice,
                        TotalWithGst = totalWithGst
                    };
                    var newOrder = _baseRepository.CreateCustomerOrder(newOrderAssign);
                    return _mapper.Map<CustomerOrderDto>(newOrder);
                case Domain.Enums.Operation.Update:
                    var editOrderAssign = new CustomerOrder
                    {
                        ProductId = request.CustomerOrder.ProductId,
                        Quantity = request.CustomerOrder.Quantity,
                        TotalPrice = totalPrice,
                        TotalWithGst = totalWithGst,
                    };
                    var editOrder = _baseRepository.UpdateCustomerOrder(request.CustomerOrder.Id, editOrderAssign);
                    return _mapper.Map<CustomerOrderDto>(editOrder);
                case Domain.Enums.Operation.Delete:
                    _baseRepository.DeleteCustomerOrder(request.CustomerOrder.Id);
                    return null;
                default:
                    throw new InvalidOperationException("Invalid operation type.");
            }
        }
    }
}
