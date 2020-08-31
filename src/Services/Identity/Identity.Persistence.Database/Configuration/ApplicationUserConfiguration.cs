﻿namespace Identity.Persistence.Database.Configuration
{
    #region Using

    using Identity.Domain;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    public class ApplicationUserConfiguration
    {
        public ApplicationUserConfiguration(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(100);

            entityBuilder.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId).IsRequired();
        }
    }
}
