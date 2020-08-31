namespace Identity.Persistence.Database.Configuration
{
    #region Using

    using Identity.Domain;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    #endregion

    public class ApplicationRoleConfiguration
    {
        public ApplicationRoleConfiguration(EntityTypeBuilder<ApplicationRole> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.HasData(
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );

            entityBuilder.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId).IsRequired();
        }
    }
}
