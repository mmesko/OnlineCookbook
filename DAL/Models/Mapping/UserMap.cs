using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OnlineCookbook.DAL.Models;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            //done manually and add migration: add-migration -Name, update-database
            HasMany(r => r.Recipes).WithRequired(u => u.User);
            HasMany(u => u.Comments).WithRequired(r => r.User);
            HasMany(u => u.MessageUsers).WithMany(r => r.Users);
            HasMany(u => u.FavouriteUsers).WithMany(r => r.Users);
           
        }
    }
}
