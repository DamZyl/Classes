using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlainClasses.Domain.Models;
using PlainClasses.Application.Configurations.Options;

namespace PlainClasses.Infrastructure.Databases.Sql
{
    public class PlainClassesContext : DbContext
    {
        #region DbSets

        public DbSet<EduBlock> EduBlocks { get; set; }
        public DbSet<EduBlockSubject> EduBlockSubjects { get; set; }
        public DbSet<MilitaryRank> MilitaryRanks { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonAuth> PersonAuths { get; set; }
        public DbSet<PersonFunction> PersonFunctions { get; set; }
        public DbSet<Platoon> Platoons { get; set; }
        public DbSet<PlatoonInEduBlock> PlatoonInEduBlocks { get; set; }
        public DbSet<Topic> Topics { get; set; }

        #endregion

        public PlainClassesContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}