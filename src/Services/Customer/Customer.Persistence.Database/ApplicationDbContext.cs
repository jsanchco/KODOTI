namespace Customer.Persistence.Database
{
    #region Using

    using Customer.Domain;
    using Customer.Persistence.Database.Configuration;
    using Microsoft.EntityFrameworkCore;

    #endregion

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Database schema
            builder.HasDefaultSchema("Client");

            // Model Contraints
            ModelConfig(builder);
        }

        public DbSet<Client> Clients { get; set; }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ClientConfiguration(modelBuilder.Entity<Client>());
        }
    }
}
