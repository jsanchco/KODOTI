namespace Customer.Tests
{
    #region Using

    using Customer.Domain;
    using Customer.Services.EventHandlers;
    using Customer.Services.EventHandlers.Commands;
    using Customer.Services.EventHandlers.Exceptions;
    using Customer.Tests.Config;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Linq;
    using System.Threading;

    #endregion

    [TestClass]
    public class ClientCreateEventHandlerTest
    {
        private ILogger<ClientCreateEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<ClientCreateEventHandler>>()
                    .Object;
            }
        }

        [TestMethod]
        public void TryCreateClientWhenNotExists()
        {
            var context = ApplicationDbContextInMemory.Get();

            var name = "Client 103";

            var handler = new ClientCreateEventHandler(context, GetLogger);
            handler.Handle(new ClientCreateCommand
            {
                Name = name
            }, new CancellationToken()).Wait();

            var clientInDb = context.Clients.Single(x => x.Name == name).Name;

            Assert.AreNotEqual(clientInDb, "name");
        }

        [TestMethod]
        [ExpectedException(typeof(ClientCreateCommandException))]
        public void TryCreateClientWhenExists()
        {
            var context = ApplicationDbContextInMemory.Get();

            var name = "Client 104";

            var handler = new ClientCreateEventHandler(context, GetLogger);
            handler.Handle(new ClientCreateCommand
            {
                Name = name
            }, new CancellationToken()).Wait();

            try
            {
                handler = new ClientCreateEventHandler(context, GetLogger);
                handler.Handle(new ClientCreateCommand
                {
                    Name = name
                }, new CancellationToken()).Wait();

                var clientInDb = context.Clients.Single(x => x.Name == name).Name;
            }
            catch (AggregateException ae)
            {
                var exception = ae.GetBaseException();

                if (exception is ClientCreateCommandException)
                {
                    throw new ClientCreateCommandException(exception.Message);
                }
            }
        }
    }
}
