using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FullName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SaltKey)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RecoweryQuestion)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RecoveryAnswer)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.SaltKey).HasColumnName("SaltKey");
            this.Property(t => t.RecoweryQuestion).HasColumnName("RecoweryQuestion");
            this.Property(t => t.RecoveryAnswer).HasColumnName("RecoveryAnswer");
        }
    }
}