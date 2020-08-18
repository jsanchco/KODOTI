namespace Customer.Tests.Config
{
    #region Using

    using Customer.Persistence.Database;
    using Microsoft.EntityFrameworkCore;

    #endregion

    public static class ApplicationDbContextInMemory
    {
        public static ApplicationDbContext Get()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"Client.Db")
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
