using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConsoleApp_Codefirst
{
    public class SchoolDbCph : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQL2019;Database=SchoolDBCphTpt1;Encrypt=False;Trusted_Connection=True;User Id=dbdebug;Password=Kode1234!;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var e in modelBuilder.Model.GetEntityTypes())
            {
                e.SetTableName(ToDatabaseIdentifier(e.Name));
                foreach (var p in e.GetProperties())
                {
                    p.SetColumnName(ToDatabaseIdentifier(p.Name));
                }
            }

            ApplyCaseMappingRule(this, modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grade>(e => e.HasMany<Student>().WithMany());
        }

        //https://stackoverflow.com/questions/51436793/ef-core-define-custom-column-mapping-strategy-for-all-properties
        public static void ApplyCaseMappingRule(DbContext dbContext, ModelBuilder modelBuilder)
        {
            var dbSetProps = typeof(DbContext).GetProperties();
            foreach (var dbSetProp in dbSetProps)
            {
                if (TryGetEntityTypeFromDbSetType(dbSetProp.PropertyType, out var entityType))
                {
                    modelBuilder.Entity(entityType, options => options.UseTptMappingStrategy());
                }
            }
        }
        private static bool TryGetEntityTypeFromDbSetType(Type dbSetType, out Type entityType)
        {
            entityType = null;
            if (dbSetType.Name != "DbSet`1") return false;
            if (dbSetType.GenericTypeArguments.Length != 1) return false;
            entityType = dbSetType.GenericTypeArguments[0];
            return true;
        }

        string ToDatabaseIdentifier(string propertyName)
        {
            string projectName = Assembly.GetCallingAssembly().GetName().Name + ".";
            string tableName = propertyName.Replace(projectName, string.Empty);
            var pluralizer = new EnglishPluralizationService();
            return pluralizer.Pluralize(tableName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolDbCph())
            {
                // Perform CRUD operations here
                // Example: Adding a student
                var newPerson = new Person("John Doe", "90807060", "Johndoe@email.com", "John steet", "John city", "John York", 22324, "Johnland");

                context.People.Add(newPerson);
                //context.Students.Add(newStudent);
                context.SaveChanges();
            }

            using (var context = new SchoolDbCph())
            {
                // Retrieve the student
                var retrievedPerson = context.People.FirstOrDefault(s => s.Name == "John Doe");
                Console.WriteLine($"Retrieved Person: {retrievedPerson.Name}, Person Number: {retrievedPerson.Id}");
            }
        }
    }
}