using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Interfaces.IQueries;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISalesReportQueries _salesReportQueries;

        public SalesReportController(IMediator mediator, ISalesReportQueries salesReportQueries)
        {
            _mediator = mediator;
            _salesReportQueries = salesReportQueries;
        }
        [HttpGet("SalesReport")]
        public SalesReportDto ResultGetSalesReport()
        {
            return _salesReportQueries.GetSalesReport();
        }
    }
}
