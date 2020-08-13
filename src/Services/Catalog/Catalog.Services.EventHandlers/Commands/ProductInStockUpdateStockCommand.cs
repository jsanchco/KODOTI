namespace Catalog.Services.EventHandlers.Commands
{
    #region Using

    using MediatR;
    using System.Collections;
    using System.Collections.Generic;
    using static Catalog.Common.Enums;

    #endregion

    public class ProductInStockUpdateStockCommand : INotification
    {
        public IEnumerable<ProductInStockUpdateItem> Items { get; set; } = new List<ProductInStockUpdateItem>();
    }

    public class ProductInStockUpdateItem
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public ProductInStockAction Action { get; set; }
    }
}
