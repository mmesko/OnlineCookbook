using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class RecipePictureMap : EntityTypeConfiguration<RecipePicture>
    {
        public RecipePictureMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.RecipePicture1)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("RecipePicture");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.RecipePicture1).HasColumnName("RecipePicture");
            this.Property(t => t.RecipeId).HasColumnName("RecipeId");

            // Relationships
            this.HasRequired(t => t.Recipe)
                .WithMany(t => t.RecipePictures)
                .HasForeignKey(d => d.RecipeId);

        }
    }
}
