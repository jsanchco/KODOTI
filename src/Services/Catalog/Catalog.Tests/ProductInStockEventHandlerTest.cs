namespace Catalog.Tests
{
    #region Using

    using Catalog.Domain;
    using Catalog.Services.EventHandlers;
    using Catalog.Services.EventHandlers.Commands;
    using Catalog.Tests.Config;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;
    using System.Threading;
    using static Catalog.Common.Enums;

    #endregion

    [TestClass]
    public class ProductInStockEventHandlerTest
    {
        private ILogger<ProductInStockUpdateStockEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<ProductInStockUpdateStockEventHandler>>()
                    .Object;                 
            }
        }

        [TestMethod]
        public void TryToSubstractStockWhenProductHasStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            var id = 1;
            var productId = 1;

            context.Stocks.Add(new ProductInStock
            {
                Id = id,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);
            handler.Handle(new ProductInStockUpdateStockCommand
            { 
                Items = new List<ProductInStockUpdateItem>() 
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 1,
                        Action = ProductInStockAction.Substract
                    }
                }
            }, new CancellationToken()).Wait();
        }
    }
}
