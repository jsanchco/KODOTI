namespace Catalog.Persistence.Database.Configuration
{
    #region Using

    using Catalog.Domain;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;

    #endregion

    public class ProductInStockConfiguration
    {
        public ProductInStockConfiguration(EntityTypeBuilder<ProductInStock> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);

            var stocks = new List<ProductInStock>();
            var random = new Random();

            for (var i = 1; i <= 100; i++)
            {
                stocks.Add(new ProductInStock
                {
                    Id = i,
                    ProductId = i,
                    Stock = random.Next(0, 100)
                });
            }

            entityBuilder.HasData(stocks);
        }
    }
}
