namespace Catalog.Services.EventHandlers
{
    #region Using

    using Catalog.Common;
    using Catalog.Domain;
    using Catalog.Persistence.Database;
    using Catalog.Services.EventHandlers.Commands;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    #endregion

    public class ProductInStockUpdateStockEventHandler : INotificationHandler<ProductInStockUpdateStockCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductInStockUpdateStockEventHandler> _logger;

        public ProductInStockUpdateStockEventHandler(
            ApplicationDbContext context,
            ILogger<ProductInStockUpdateStockEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(ProductInStockUpdateStockCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- ProductInStockUpdateStockCommand started");

            var products = command.Items.Select(x => x.ProductId);
            var stocks = await _context.Stocks.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation("--- Retrieve products from database");

            foreach (var item in command.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);
                if (item.Action == Enums.ProductInStockAction.Substract)
                {
                    if (entry == null)
                    {
                        _logger.LogError($"--- This Product: {item.ProductId} - doesn't exist");

                        throw new Exception($"This Product: {item.ProductId} - doesn't exist");
                    }

                    if (item.Stock > entry.Stock)
                    {
                        _logger.LogError($"--- Product {entry.ProductId} - doesn´t have enough stock");

                        throw new Exception($"Product {entry.ProductId} - doesn´t have enough stock");
                    }

                    entry.Stock -= item.Stock;
                    _logger.LogInformation($"--- Product {entry.ProductId} - its stocks was substracted and its new stock is {entry.Stock}");
                }
                else
                {
                    if (entry == null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };

                        await _context.AddAsync(entry);
                        _logger.LogInformation($"--- New stock record was created for {entry.ProductId} because didn't exists before");
                    }

                    entry.Stock += item.Stock;
                    _logger.LogInformation($"--- Product {entry.ProductId} - its stocks was increased and its new stock is {entry.Stock}");
                }
            }

            await _context.SaveChangesAsync();
            _logger.LogInformation("--- ProductInStockUpdateStockCommand ended");
        }
    }
}
