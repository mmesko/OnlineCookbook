using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class FavouriteMap : EntityTypeConfiguration<Favourite>
    {
        public FavouriteMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.RecipeId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.FavouriteName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Abrv)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Favourite");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RecipeId).HasColumnName("RecipeId");
            this.Property(t => t.FavouriteName).HasColumnName("FavouriteName");
            this.Property(t => t.Abrv).HasColumnName("Abrv");

            // Relationships
            this.HasRequired(t => t.Recipe)
                .WithMany(t => t.Favourites)
                .HasForeignKey(d => d.RecipeId);

        }
    }
}
