using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TextMessage)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Message");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TextMessage).HasColumnName("TextMessage");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
        }
    }
}
