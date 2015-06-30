using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class IdentityRoleMap : EntityTypeConfiguration<IdentityRole>
    {
        public IdentityRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.RoleTitle)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Abrv)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("IdentityRole");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RoleTitle).HasColumnName("RoleTitle");
            this.Property(t => t.Abrv).HasColumnName("Abrv");
        }
    }
}
