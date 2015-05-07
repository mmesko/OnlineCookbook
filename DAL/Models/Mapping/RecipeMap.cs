using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class RecipeMap : EntityTypeConfiguration<Recipe>
    {
        public RecipeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.RecipeTitle)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RecipeDescription)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RecipeText)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Recipe");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RecipeTitle).HasColumnName("RecipeTitle");
            this.Property(t => t.RecipeDescription).HasColumnName("RecipeDescription");
            this.Property(t => t.RecipeComplexity).HasColumnName("RecipeComplexity");
            this.Property(t => t.RecipeText).HasColumnName("RecipeText");
            this.Property(t => t.Abrv).HasColumnName("Abrv");
            this.Property(t => t.HasPicture).HasColumnName("HasPicture");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Recipes)
                .HasForeignKey(d => d.CategoryId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Recipes)
                .HasForeignKey(d => d.UserId);

        }
    }
}
