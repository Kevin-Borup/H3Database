using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Codefirst
{

    public class Person
    {
        [Required]
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
        public Address address { get; set; }
        public LibraryCard? libraryCard { get; set; }
        public Person(int id, string name, string phoneNumber, string emailAddress, string street, string city, string state, int zipcode, string country)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.emailAddress = emailAddress;

            this.libraryCard = null;

            address = new Address()
            {
                street = street,
                city = city,
                state = state,
                zipcode = zipcode,
                country = country
            };
        }
    }

    public class Teacher : Person
    {
        public string subject { get; set; }
        public List<Course> courses { get; set; }
        public Teacher(int id, string name, string phoneNumber, string emailAddress, string street, string city, string state, int zipcode, string country) : base(id, name, phoneNumber, emailAddress, street, city, state, zipcode, country)
        {

        }
    }

    public class Student : Person
    {
        public int studentNumber { get; set; }
        public double averageMark 
        {
            get
            {
                //Calculate average grades
                return 7;
            }
        }
        public List<Grade> grades { get; set; }
        public List<Course> courses { get; set; }
        public Student(int studentNumber, int id, string name, string phoneNumber, string emailAddress, string street, string city, string state, int zipcode, string country) : base(id, name,phoneNumber, emailAddress, street, city, state, zipcode, country)
        {
            this.studentNumber = studentNumber;
            this.grades = null;
            this.courses = null;
        }
    }

    public class LibraryCard
    {
        [Required]
        public int userID { get; set; }
        public int rentedBooks { get; set; }
        public DateTime creationDate { get; set; }
    }

    public class Address
    { 
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }
        public string country { get; set; }
    }

    public class Course
    {
        [Required]
        public int courseID { get; set; }
        public string courseName { get; set; }
        public List<Student> students { get; set; }
        public List<Teacher> teachers { get; set; }
    }

    public class Grade
    {
        [Required]
        public int gradeID { get; set; }
        [Required]   
        public string subject { get; set;}
        [Required]
        public int value { get; set; }
    }
}
