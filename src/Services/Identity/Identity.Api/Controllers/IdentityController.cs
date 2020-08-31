namespace Identity.Api.Controllers
{
    #region Using

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    #endregion

    [ApiController]
    [Route("v1/identity")]
    public class IdentityController : ControllerBase
    {
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(
            ILogger<IdentityController> logger)
        {
            _logger = logger;
        }
    }
}

