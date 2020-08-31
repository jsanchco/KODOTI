namespace Identity.Domain
{
    #region Using

    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    #endregion

    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
