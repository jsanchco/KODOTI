namespace Order.Service.Proxies.Catalog
{
    #region Using

    using Microsoft.Azure.ServiceBus;
    using Microsoft.Extensions.Options;
    using Order.Service.Proxies.Catalog.Commands;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    #endregion

    public class CatalogQueueProxy : ICatalogProxy
    {
        public readonly AzureServiceBus _azureServiceBus;

        public CatalogQueueProxy(IOptions<AzureServiceBus> azureServiceBus)
        {
            _azureServiceBus = azureServiceBus.Value;
        }

        public async Task UpdateStockAsync(ProductInStockUpdateStockCommand command)
        {
            var queueClient = new QueueClient(_azureServiceBus.ConnectionString, "order-stock-update");

            // Serialize message
            var body = JsonSerializer.Serialize(command);
            var message = new Message(Encoding.UTF8.GetBytes(body));

            // Send the message to the queue
            await queueClient.SendAsync(message);

            // Close
            await queueClient.CloseAsync();
        }
    }
}
