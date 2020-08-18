namespace Customer.Api.Controllers
{
    #region Using

    using Customer.Services.EventHandlers.Commands;
    using Customer.Services.Queries;
    using Customer.Services.Queries.DTOs;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Service.Common.Collection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    #endregion

    [ApiController]
    [Route("v1/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientQueryService _clientQueryService;
        private readonly IMediator _mediator;

        public ClientsController(
            ILogger<ClientsController> logger,
            IClientQueryService clientQueryService,
            IMediator mediator)
        {
            _logger = logger;
            _clientQueryService = clientQueryService;
            _mediator = mediator;
        }

        // clients
        [HttpGet]
        public async Task<DataCollection<ClientDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> products = null;

            if (!string.IsNullOrEmpty(ids))
            {
                products = ids.Split(",").Select(x => Convert.ToInt32(x));
            }

            return await _clientQueryService.GetAllAsync(page, take, products);
        }

        // clients/1
        [HttpGet("{id}")]
        public async Task<ClientDto> Get(int id)
        {
            return await _clientQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateCommand command)
        {
            await _mediator.Publish(command);

            return Ok();
        }
    }
}
