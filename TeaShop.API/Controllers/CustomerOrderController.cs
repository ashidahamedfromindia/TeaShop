using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Application.Commands.OrderCommandFolder;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Enums;
using TeaShop.Domain.Interfaces.IQueries;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICustomerQueries _customerQueries;

        public CustomerOrderController(IMediator mediator, ICustomerQueries customerQueries)
        {
            _mediator = mediator;
            _customerQueries = customerQueries;
        }
        [HttpGet("ALL ORDERS")]
        public List<CustomerOrderDto> GetOrders()
        {
            return _customerQueries.GetAllOrder();
        }
        [HttpGet("FIND ORDER BY ID")]
        public CustomerOrderDto GetOrderById(int id)
        {
            return _customerQueries.GetCustomerOrder(id);
        }
        [HttpPost("CREATE NEW ORDER")]
        public ActionResult PostCreateOrder(CustomerOrderforPostDto categoryDto)
        {
            var command = new OrderCommand(Operation.Create, categoryDto);
            var newCAt = _mediator.Send(command);
            return Ok(newCAt);
        }
        [HttpPut("EDIT ORDER{id}")]
        public ActionResult PutEditOrder(int id, CustomerOrderforPostDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest();
            }
            var command = new OrderCommand(Operation.Update, categoryDto);
            _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("DELETE ORDER{id}")]
        public ActionResult DeleteOrder(int id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var DeleteId = new CustomerOrderforPostDto { Id = id };
            var command = new OrderCommand(Operation.Delete, DeleteId);
            _mediator.Send(command.CustomerOrder.Id);
            return NoContent();

        }
    }
}
