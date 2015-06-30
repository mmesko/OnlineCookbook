using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class IdentityUserClaim
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public virtual User User { get; set; }
    }
}
