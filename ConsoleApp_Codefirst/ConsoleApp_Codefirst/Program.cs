using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            optionsBuilder.UseSqlServer(@"Server=.\SQL2019;Database=SchoolDBCphTpt;Encrypt=False;Trusted_Connection=True;User Id=dbdebug;Password=Kode1234!;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(e => e.UseTptMappingStrategy());
            modelBuilder.Entity<Teacher>(e => e.UseTptMappingStrategy());
            modelBuilder.Entity<Student>(e => e.UseTptMappingStrategy());
            modelBuilder.Entity<Grade>(e => e.UseTptMappingStrategy());
            modelBuilder.Entity<Address>(e => e.UseTptMappingStrategy());
            modelBuilder.Entity<Course>(e => e.UseTptMappingStrategy());
            modelBuilder.Entity<LibraryCard>(e => e.UseTptMappingStrategy());
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
                var newStudent = new Student(1, 1, "John Doe", "90807060", "Johndoe@email.com", "John steet", "John city", "John York", 22324, "Johnland");

                context.Students.Add(newStudent);
                context.SaveChanges();
            }

            using (var context = new SchoolDbCph())
            {
                // Retrieve the student
                var retrievedStudent = context.Students.FirstOrDefault(s => s.Name == "John Doe");
                Console.WriteLine($"Retrieved Student: {retrievedStudent.Name}, Student Number: {retrievedStudent.studentID}");
            }
        }
    }
}