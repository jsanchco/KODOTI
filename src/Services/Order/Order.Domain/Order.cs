namespace Order.Domain
{
    #region Uisng

    using System;
    using System.Collections.Generic;
    using static global::Order.Common.Enums;

    #endregion

    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public OrderPayment PaymentType { get; set; }
        public int ClientId { get; set; }
        public ICollection<OrderDetail> Items { get; set; } = new List<OrderDetail>();
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }
    }
}
