using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class RecipeIngradientMap : EntityTypeConfiguration<RecipeIngradient>
    {
        public RecipeIngradientMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.IngradientId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.RecipeId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.IngradientUnit)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("RecipeIngradient");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IngradientId).HasColumnName("IngradientId");
            this.Property(t => t.RecipeId).HasColumnName("RecipeId");
            this.Property(t => t.IngradientQuantity).HasColumnName("IngradientQuantity");
            this.Property(t => t.IngradientUnit).HasColumnName("IngradientUnit");

            // Relationships
            this.HasRequired(t => t.Ingradient)
                .WithMany(t => t.RecipeIngradients)
                .HasForeignKey(d => d.IngradientId);
            this.HasRequired(t => t.Recipe)
                .WithMany(t => t.RecipeIngradients)
                .HasForeignKey(d => d.RecipeId);

        }
    }
}
