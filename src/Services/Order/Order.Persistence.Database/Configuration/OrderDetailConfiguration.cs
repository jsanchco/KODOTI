namespace Order.Persistence.Database.Configuration
{
    #region Using

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    public class OrderDetailConfiguration
    {
        public OrderDetailConfiguration(EntityTypeBuilder<Domain.OrderDetail> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
            entityBuilder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
            entityBuilder.Property(x => x.Total).HasColumnType("decimal(18,2)");
        }
    }
}
