using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class AspNetRole
    {   
        //added by migrations, than do EF reverse,CF
        public AspNetRole()
        {
            this.AspNetUsers = new List<AspNetUser>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
