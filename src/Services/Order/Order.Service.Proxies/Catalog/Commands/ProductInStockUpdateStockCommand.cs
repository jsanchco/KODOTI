namespace Order.Service.Proxies.Catalog.Commands
{
    #region Using

    using System.Collections.Generic;

    #endregion

    public enum ProductInStockAction
    {
        Add,
        Substract
    }

    public class ProductInStockUpdateStockCommand
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
