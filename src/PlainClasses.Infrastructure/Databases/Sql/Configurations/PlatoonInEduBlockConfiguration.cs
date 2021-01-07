using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlainClasses.Domain.EduBlocks;

namespace PlainClasses.Infrastructure.Databases.Sql.Configurations
{
    public class PlatoonInEduBlockConfiguration : IEntityTypeConfiguration<PlatoonInEduBlock>
    {
        public void Configure(EntityTypeBuilder<PlatoonInEduBlock> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.HasOne(x => x.Platoon)
                .WithMany(x => x.Platoons)
                .HasForeignKey(x => x.PlatoonId);
            
            builder.HasOne(x => x.EduBlock)
                .WithMany(x => x.Platoons)
                .HasForeignKey(x => x.EduBlockId);
        }
    }
}