using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class PreparationStepPictureMap : EntityTypeConfiguration<PreparationStepPicture>
    {
        public PreparationStepPictureMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.StepPicture)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("PreparationStepPicture");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PreparationStepId).HasColumnName("PreparationStepId");
            this.Property(t => t.StepPicture).HasColumnName("StepPicture");

            // Relationships
            this.HasRequired(t => t.PreparationStep)
                .WithMany(t => t.PreparationStepPictures)
                .HasForeignKey(d => d.PreparationStepId);

        }
    }
}
