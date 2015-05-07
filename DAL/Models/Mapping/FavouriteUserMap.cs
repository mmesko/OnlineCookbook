using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class FavouriteUserMap : EntityTypeConfiguration<FavouriteUser>
    {
        public FavouriteUserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("FavouriteUser");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.FavouriteId).HasColumnName("FavouriteId");

            // Relationships
            this.HasRequired(t => t.Favourite)
                .WithMany(t => t.FavouriteUsers)
                .HasForeignKey(d => d.FavouriteId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.FavouriteUsers)
                .HasForeignKey(d => d.UserId);

        }
    }
}
