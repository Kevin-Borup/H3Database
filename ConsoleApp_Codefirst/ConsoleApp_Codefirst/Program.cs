using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_Codefirst
{
    // Represents the database context for the application
    public class SchoolDbCph : DbContext
    {
        // Define DbSet properties for each entity in the database
        public DbSet<Person> People { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }

        // Configure the database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQL2019;Database=SchoolDBCph1;Encrypt=False;Trusted_Connection=True;User Id=dbdebug;Password=Kode1234!;");
        }

        // Configure the model relationships and database constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Summary: Define the relationships and constraints between entities in the database model
            // Example: Configure many-to-many relationship between Course and Student entities
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.courses)
                .UsingEntity(j => j.ToTable("CourseStudent"));

            // Example: Define unique constraint on EmailAddress in the Person entity
            modelBuilder.Entity<Person>()
                .HasIndex(p => p.EmailAddress)
                .IsUnique();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the database context
            using (var context = new SchoolDbCph())
            {
                // Create a new student object
                var newStudent = new Student(1, 1, "John Doe", "90807060", "Johndoe@email.com", "John steet", "John city", "John York", 22324, "Johnland");

                // Add the new student to the Students DbSet and save changes to the database
                context.Students.Add(newStudent);
                context.SaveChanges();
            }

            // Create another instance of the database context
            using (var context = new SchoolDbCph())
            {
                // Retrieve the student with the name "John Doe" from the Students DbSet
                var retrievedStudent = context.Students.FirstOrDefault(s => s.Name == "John Doe");
                Console.WriteLine($"Retrieved Student: {retrievedStudent.Name}, Student Number: {retrievedStudent.studentID}");
            }
        }
    }
}