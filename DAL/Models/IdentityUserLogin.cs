using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class IdentityUserLogin
    {
        public string Id { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
