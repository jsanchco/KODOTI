namespace Customer.Services.EventHandlers
{
    #region Using

    using Customer.Domain;
    using Customer.Persistence.Database;
    using Customer.Services.EventHandlers.Commands;
    using Customer.Services.EventHandlers.Exceptions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;

    #endregion

    public class ClientCreateEventHandler : INotificationHandler<ClientCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ClientCreateEventHandler> _logger;

        public ClientCreateEventHandler(
            ApplicationDbContext context,
            ILogger<ClientCreateEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(ClientCreateCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- ClientCreateCommand started");

            var clientExist = await _context.Clients.FirstOrDefaultAsync(x => x.Name == command.Name);
            if (clientExist != null)
            {
                _logger.LogError($"The client with this name: '{command.Name}' exists");

                throw new ClientCreateCommandException($"The client with this name: '{command.Name}' exists");
            }

            await _context.AddAsync(new Client
            {
                Name = command.Name
            });

            await _context.SaveChangesAsync();

            _logger.LogInformation("--- ClientCreateCommand ended");
        }
    }
}
