namespace Customer.Services.EventHandlers.Commands
{
    #region Using

    using MediatR;

    #endregion

    public class ClientCreateCommand : INotification
    {
        public string Name { get; set; }
    }
}
