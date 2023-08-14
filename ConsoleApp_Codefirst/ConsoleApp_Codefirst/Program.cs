using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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

                // Retrieve the student
                var retrievedStudent = context.Students.FirstOrDefault(s => s.name == "John Doe");
                Console.WriteLine($"Retrieved Student: {retrievedStudent.name}, Student Number: {retrievedStudent.studentNumber}");
            }
        }
    }
}