using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Codefirst
{
    // Represents a person with common attributes
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
        public LibraryCard LibraryCard { get; set; }

        public Person()
        {
            // Initialize properties if necessary
        }

        public Person(int id, string name, string phoneNumber, string emailAddress, string street, string city, string state, int zipcode, string country)
        {
            // Initialize the properties of the person
        }
    }

    // Represents a teacher, inherits from Person
    public class Teacher : Person
    {
        public int TeacherID { get; set; }
        public string subject { get; set; }
        public List<Course> courses { get; set; }

        public Teacher()
        {
            // Initialize properties if necessary
        }

        public Teacher(int id, string name, string phoneNumber, string emailAddress, string street, string city, string state, int zipcode, string country)
            : base(id, name, phoneNumber, emailAddress, street, city, state, zipcode, country)
        {
            // Existing constructor logic
        }
    }

    // Represents a student, inherits from Person
    public class Student : Person
    {
        public int studentID { get; set; }
        public double averageMark
        {
            get
            {
                return 7;
            }
        }
        public List<Grade> grades { get; set; }
        public List<Course> courses { get; set; }

        public Student()
        {
            // Initialize properties if necessary
        }

        public Student(int studentNumber, int id, string name, string phoneNumber, string emailAddress, string street, string city, string state, int zipcode, string country)
            : base(id, name, phoneNumber, emailAddress, street, city, state, zipcode, country)
        {
            // Initialize student-specific properties
        }
    }

    // Represents a library card for a user
    public class LibraryCard
    {
        [Key]
        public int UserId { get; set; }
        public int RentedBooks { get; set; }
        public DateTime CreationDate { get; set; }
    }

    // Represents an address
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }
    }

    // Represents a course
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
    }

    // Represents a grade for a subject
    public class Grade
    {
        [Required]
        public int gradeID { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public int value { get; set; }
    }
}