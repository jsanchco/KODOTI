namespace Identity.Domain
{
    #region Using

    using Microsoft.AspNetCore.Identity;

    #endregion

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationRole Role { get; set; }
        public ApplicationUser User { get; set; }
    }
}
