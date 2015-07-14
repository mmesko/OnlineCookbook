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
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.FavouriteId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("FavouriteUser");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.FavouriteId).HasColumnName("FavouriteId");

            // Relationships
            this.HasRequired(t => t.Favourite)
                .WithMany(t => t.FavouriteUsers)
                .HasForeignKey(d => d.FavouriteId);

        }
    }
}
