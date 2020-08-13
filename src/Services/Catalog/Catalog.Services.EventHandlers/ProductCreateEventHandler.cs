﻿namespace Catalog.Services.EventHandlers
{
    #region Using

    using Catalog.Domain;
    using Catalog.Persistence.Database;
    using Catalog.Services.EventHandlers.Commands;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    #endregion

    public class ProductCreateEventHandler : INotificationHandler<ProductCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public ProductCreateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ProductCreateCommand command, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Product
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price
            });

            await _context.SaveChangesAsync();
        }
    }
}
