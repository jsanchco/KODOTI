namespace Api.Gateway.Models.Orders.Commands
{
    #region Using

    using System.Collections.Generic;
    using static Api.Gateway.Models.Order.Commons.Enums;

    #endregion

    public class OrderCreateCommand
    {
        public OrderPayment PaymentType { get; set; }
        public int ClientId { get; set; }
        public IEnumerable<OrderCreateDetail> Items { get; set; } = new List<OrderCreateDetail>();
    }

    public class OrderCreateDetail
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
