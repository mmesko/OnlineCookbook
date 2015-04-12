using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class PreparationStepMap : EntityTypeConfiguration<PreparationStep>
    {
        public PreparationStepMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PreparationText)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("PreparationStep");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.StepNumber).HasColumnName("StepNumber");
            this.Property(t => t.PreparationText).HasColumnName("PreparationText");
            this.Property(t => t.RecipeId).HasColumnName("RecipeId");

            // Relationships
            this.HasRequired(t => t.Recipe)
                .WithMany(t => t.PreparationSteps)
                .HasForeignKey(d => d.RecipeId);

        }
    }
}
