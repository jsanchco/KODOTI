namespace Catalog.Services.EventHandlers.Exceptions
{
    #region Using

    using System;

    #endregion

    public class ProductInStockUpdateStockCommandException : Exception
    {
        public ProductInStockUpdateStockCommandException(string message) : base(message)
        {

        }
    }
}
