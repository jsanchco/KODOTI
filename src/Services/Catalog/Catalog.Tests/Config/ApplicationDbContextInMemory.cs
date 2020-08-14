namespace Catalog.Tests.Config
{
    #region Using

    using Catalog.Persistence.Database;
    using Microsoft.EntityFrameworkCore;

    #endregion

    public static class ApplicationDbContextInMemory
    {
        public static ApplicationDbContext Get()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"Catalog.Db")
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
