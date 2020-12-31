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

            builder.Property(x => x.PersonalNumber)
                .HasMaxLength(11)
                .IsRequired();
            
            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(70)
                .IsRequired();

            builder.Property(x => x.FatherName)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.PersonalPhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.WorkPhoneNumber)
                .HasMaxLength(15);

            builder.Property(x => x.MilitaryRankAcr)
                .HasMaxLength(15)
                .IsRequired();
            
            builder.Property(x => x.PlatoonAcr)
                .HasMaxLength(5)
                .IsRequired();

            builder.HasOne(x => x.MilitaryRank)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.MilitaryRankId);
            
            builder.HasOne(x => x.Platoon)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.PlatoonId);
            
            builder.Property(x => x.Position)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}