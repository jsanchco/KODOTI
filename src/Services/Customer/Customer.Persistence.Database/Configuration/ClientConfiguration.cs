namespace Customer.Persistence.Database.Configuration
{
    #region Using

    using Customer.Domain;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    #endregion

    public class ClientConfiguration
    {
        public ClientConfiguration(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            var clients = new List<Client>();

            for (var i = 1; i <= 100; i++)
            {
                clients.Add(new Client
                {
                    Id = i,
                    Name = $"Client {i}"
                });
            }

            entityBuilder.HasData(clients);
        }
    }
}
