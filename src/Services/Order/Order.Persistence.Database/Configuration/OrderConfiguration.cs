namespace Order.Persistence.Database.Configuration
{
    #region Using

    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    public class OrderConfiguration
    {
        public OrderConfiguration(EntityTypeBuilder<Domain.Order> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}
