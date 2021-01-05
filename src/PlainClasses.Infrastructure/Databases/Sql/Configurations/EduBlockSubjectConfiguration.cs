using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlainClasses.Domain.Models;

namespace PlainClasses.Infrastructure.Databases.Sql.Configurations
{
    public class EduBlockSubjectConfiguration : IEntityTypeConfiguration<EduBlockSubject>
    {
        public void Configure(EntityTypeBuilder<EduBlockSubject> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}