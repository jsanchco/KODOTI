namespace Catalog.Tests
{
    #region Using

    using Catalog.Domain;
    using Catalog.Services.EventHandlers;
    using Catalog.Services.EventHandlers.Commands;
    using Catalog.Services.EventHandlers.Exceptions;
    using Catalog.Tests.Config;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
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

        [TestMethod]
        [ExpectedException(typeof(ProductInStockUpdateStockCommandException))]
        public void TryToSubstractStockWhenProductHasntStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            var id = 2;
            var productId = 2;

            context.Stocks.Add(new ProductInStock
            {
                Id = id,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);
            try
            {
                handler.Handle(new ProductInStockUpdateStockCommand
                {
                    Items = new List<ProductInStockUpdateItem>()
                    {
                        new ProductInStockUpdateItem
                        {
                            ProductId = productId,
                            Stock = 2,
                            Action = ProductInStockAction.Substract
                        }
                    }
                }, new CancellationToken()).Wait();
            }
            catch(AggregateException ae)
            {
                var exception = ae.GetBaseException();

                if (exception is ProductInStockUpdateStockCommandException)
                {
                    throw new ProductInStockUpdateStockCommandException(exception.Message);
                }
            }
        }

        [TestMethod]
        public void TryToAddStockWhenProductExists()
        {
            var context = ApplicationDbContextInMemory.Get();

            var id = 3;
            var productId = 3;

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
                        Stock = 2,
                        Action = ProductInStockAction.Add
                    }
                }
            }, new CancellationToken()).Wait();

            var stockInDb = context.Stocks.Single(x => x.Id == productId).Stock;

            Assert.AreEqual(stockInDb, 3);
        }

        [TestMethod]
        public void TryToAddStockWhenProductNotExists()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productId = 4;

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);
            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Add
                    }
                }
            }, new CancellationToken()).Wait();

            var stockInDb = context.Stocks.Single(x => x.ProductId == productId).Stock;

            Assert.AreEqual(stockInDb, 2);
        }
    }
}
