namespace Order.Service.Proxies.Catalog
{
    #region Using

    using Order.Service.Proxies.Catalog.Commands;
    using System.Threading.Tasks;

    #endregion

    public interface ICatalogProxy
    {
        Task UpdateStockAsync(ProductInStockUpdateStockCommand command);
    }
}
