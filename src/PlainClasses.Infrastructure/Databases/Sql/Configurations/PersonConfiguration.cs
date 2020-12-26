using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlainClasses.Domain.Models;

namespace PlainClasses.Infrastructure.Databases.Sql.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.MilitaryRank)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.MilitaryRankId);
            
            builder.HasOne(x => x.Platoon)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.PlatoonId);
            
            builder.Property(x => x.Position)
                .HasConversion<string>();
        }
    }
}