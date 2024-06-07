using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitasChallenge.DAL.Entities.Configurations
{
    public class TasksConfiguration : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.HasKey(t => t.Id).IsClustered();
            builder.Property(t => t.Id).HasColumnName("Id").HasColumnType("int");
            builder.Property(t => t.Name).HasColumnName("Name").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(t => t.Description).HasColumnName("Description").HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(t => t.Starts).HasColumnName("Starts").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.Ends).HasColumnName("Ends").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.Status).HasColumnName("Status").HasColumnType("varchar").HasMaxLength(20).IsRequired();
        }
    }
}