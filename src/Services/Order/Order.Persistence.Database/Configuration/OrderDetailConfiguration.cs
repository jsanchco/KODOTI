namespace Order.Persistence.Database.Configuration
{
    #region Using

    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    public class OrderDetailConfiguration
    {
        public OrderDetailConfiguration(EntityTypeBuilder<Domain.OrderDetail> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}
