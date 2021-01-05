using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlainClasses.Domain.Models;
using PlainClasses.Application.Configurations.Options;

namespace PlainClasses.Infrastructure.Databases.Sql
{
    public class PlainClassesContext : DbContext
    {
        // private readonly IOptions<SqlOption> _sqlOption;
        
        #region DbSets

        public DbSet<EduBlock> EduBlocks { get; set; }
        public DbSet<EduBlockSubject> EduBlockSubjects { get; set; }
        public DbSet<MilitaryRank> MilitaryRanks { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonAuth> PersonAuths { get; set; }
        public DbSet<PersonFunction> PersonFunctions { get; set; }
        public DbSet<Platoon> Platoons { get; set; }
        public DbSet<PlatoonInEduBlock> PlatoonInEduBlocks { get; set; }

        #endregion
        
        public PlainClassesContext(DbContextOptions options) : base(options) { }

        // public PlainClassesContext(IOptions<SqlOption> sqlOption)
        // {
        //     _sqlOption = sqlOption;
        // }
        //
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (optionsBuilder.IsConfigured)
        //     {
        //         return;
        //     }
        //
        //     optionsBuilder.UseSqlServer(_sqlOption.Value.ConnectionString, 
        //         options => options.MigrationsAssembly("PlainClasses.Api"));
        // }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}