﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Codefirst
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
        public LibraryCard LibraryCard { get; set; }

        // Parameterless constructor
        public Person()
        {
            Address = new Address();
            LibraryCard = new LibraryCard();
        }

        // Parameterized constructor
        public Person(int id, string name, string phoneNumber, string emailAddress, string street, string city, string state, int zipcode, string country)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;

            LibraryCard = null;

            Address = new Address
            {
                Street = street,
                City = city,
                State = state,
                Zipcode = zipcode,
                Country = country
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
        public Student(int studentNumber, int id, string name, string phoneNumber, string emailAddress, string street, string city, string state, int zipcode, string country) : base(id, name, phoneNumber, emailAddress, street, city, state, zipcode, country)
        {
            this.studentNumber = studentNumber;
            this.grades = null;
            this.courses = null;
        }
    }

    public class LibraryCard
    {
        [Key]
        public int UserId { get; set; }
        public int RentedBooks { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }
    }

    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
    }

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