using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlainClasses.Domain.Models;

namespace PlainClasses.Infrastructure.Databases.Sql.Configurations
{
    public class PersonFunctionConfiguration : IEntityTypeConfiguration<PersonFunction>
    {
        public void Configure(EntityTypeBuilder<PersonFunction> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.Person)
                .WithMany(x => x.PersonFunctions)
                .HasForeignKey(x => x.PersonId);
            
            builder.HasOne(x => x.EduBlock)
                .WithMany(x => x.PersonFunctions)
                .HasForeignKey(x => x.EduBlockId);
            
            builder.Property(x => x.Function)
                .HasConversion<string>();
        }
    }
}