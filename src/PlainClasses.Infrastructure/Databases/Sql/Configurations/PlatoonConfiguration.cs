using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlainClasses.Domain.Models;

namespace PlainClasses.Infrastructure.Databases.Sql.Configurations
{
    public class PlatoonConfiguration : IEntityTypeConfiguration<Platoon>
    {
        public void Configure(EntityTypeBuilder<Platoon> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}