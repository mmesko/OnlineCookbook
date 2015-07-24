using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class RecipePictureMap : EntityTypeConfiguration<RecipePicture>
    {
        public RecipePictureMap()
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

            this.Property(t => t.Picture)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("RecipePicture");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RecipeId).HasColumnName("RecipeId");
            this.Property(t => t.Picture).HasColumnName("Picture");

            // Relationships
            this.HasRequired(t => t.Recipe)
                .WithMany(t => t.RecipePictures)
                .HasForeignKey(d => d.RecipeId);

        }
    }
}
