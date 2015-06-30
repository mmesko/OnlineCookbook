using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class RecipeAlergenMap : EntityTypeConfiguration<RecipeAlergen>
    {
        public RecipeAlergenMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.AlergenId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.RecipeId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.AlergenUnit)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("RecipeAlergen");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AlergenId).HasColumnName("AlergenId");
            this.Property(t => t.RecipeId).HasColumnName("RecipeId");
            this.Property(t => t.AlergenQuantity).HasColumnName("AlergenQuantity");
            this.Property(t => t.AlergenUnit).HasColumnName("AlergenUnit");

            // Relationships
            this.HasRequired(t => t.Alergen)
                .WithMany(t => t.RecipeAlergens)
                .HasForeignKey(d => d.AlergenId);
            this.HasRequired(t => t.Recipe)
                .WithMany(t => t.RecipeAlergens)
                .HasForeignKey(d => d.RecipeId);

        }
    }
}
