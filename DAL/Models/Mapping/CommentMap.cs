using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineCookbook.DAL.Models.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.RecipeId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.CommentText)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Comment");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RecipeId).HasColumnName("RecipeId");
            this.Property(t => t.CommentText).HasColumnName("CommentText");
            

            // Relationships
            this.HasRequired(t => t.Recipe)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.RecipeId);

            this.HasRequired(u => u.User)
                .WithMany(r => r.Comments)
                .HasForeignKey(u => u.UserId);

        }
    }
}
