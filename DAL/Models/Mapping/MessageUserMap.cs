using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class MessageUserMap : EntityTypeConfiguration<MessageUser>
    {
        public MessageUserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MessageUser");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MessageId).HasColumnName("MessageId");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Relationships
            this.HasRequired(t => t.Message)
                .WithMany(t => t.MessageUsers)
                .HasForeignKey(d => d.MessageId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.MessageUsers)
                .HasForeignKey(d => d.UserId);

        }
    }
}
