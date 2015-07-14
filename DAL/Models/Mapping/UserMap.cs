using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OnlineCookbook.DAL.Models;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {

            //HasMany(u => u.Comments).WithRequired(r => r.User);
            HasMany(u => u.MessageUsers).WithMany(r => r.Users);
           
        }
    }
}
