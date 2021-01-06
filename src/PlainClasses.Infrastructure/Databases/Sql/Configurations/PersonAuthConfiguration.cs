﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlainClasses.Domain.Persons;

namespace PlainClasses.Infrastructure.Databases.Sql.Configurations
{
    public class PersonAuthConfiguration : IEntityTypeConfiguration<PersonAuth>
    {
        public void Configure(EntityTypeBuilder<PersonAuth> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.PersonAuths)
                .HasForeignKey(x => x.PersonId);
        }
    }
}