using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlainClasses.Domain.Models;

namespace PlainClasses.Infrastructure.Databases.Sql.Configurations
{
    public class EduBlockConfiguration : IEntityTypeConfiguration<EduBlock>
    {
        public void Configure(EntityTypeBuilder<EduBlock> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.EduBlockSubject)
                .WithMany(x => x.EduBlocks)
                .HasForeignKey(x => x.EduBlockSubjectId);
            
            builder.Property(x => x.Place)
                .HasConversion<string>();
        }
    }
}