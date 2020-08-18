#region Using

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order.Service.EventHandlers.Commands;
using Order.Services.Queries;
using Order.Services.Queries.DTOs;
using Service.Common.Collection;
using System.Threading.Tasks;

#endregion

namespace Order.Api.Controllers
{
    [ApiController]
    [Route("v1/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderQueryService _orderQueryService;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;

        public OrdersController(
            ILogger<OrdersController> logger,
            IMediator mediator,
            IOrderQueryService orderQueryService)
        {
            _logger = logger;
            _mediator = mediator;
            _orderQueryService = orderQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<OrderDto>> GetAll(int page = 1, int take = 10)
        {
            return await _orderQueryService.GetAllAsync(page, take);
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            return await _orderQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }
    }
}
