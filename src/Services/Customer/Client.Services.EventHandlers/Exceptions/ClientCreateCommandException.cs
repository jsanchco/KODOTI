namespace Customer.Services.EventHandlers.Exceptions
{
    #region Using

    using System;

    #endregion

    public class ClientCreateCommandException : Exception
    {
        public ClientCreateCommandException(string message) : base(message)
        {

        }
    }
}
