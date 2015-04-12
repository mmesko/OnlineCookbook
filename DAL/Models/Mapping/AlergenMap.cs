using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class AlergenMap : EntityTypeConfiguration<Alergen>
    {
        public AlergenMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AlergenName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Alergen");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AlergenName).HasColumnName("AlergenName");
        }
    }
}
