namespace Catalog.Services.EventHandlers.Commands
{
    #region Using

    using MediatR;

    #endregion

    public class ProductCreateCommand : INotification
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
