USE SchoolDBRingsted1

DROP TABLE IF EXISTS dbo.TeacherCourses
DROP TABLE IF EXISTS dbo.StudentCourses
DROP TABLE IF EXISTS dbo.StudentGrades
DROP TABLE IF EXISTS dbo.Students
DROP TABLE IF EXISTS dbo.Teachers
DROP TABLE IF EXISTS dbo.LibraryCards
DROP TABLE IF EXISTS dbo.Courses
DROP TABLE IF EXISTS dbo.Grades
DROP TABLE IF EXISTS dbo.Persons
DROP TABLE IF EXISTS dbo.Addresses


CREATE TABLE Addresses (
	ID uniqueidentifier PRIMARY KEY not null,
	Street varchar(255),
	City varchar(255),
	State varchar(255) NULL,
	PostalCode int,
	Country varchar(255)
);

CREATE TABLE Persons (
	ID uniqueidentifier not null,
	Name varchar(255) not null,
	PhoneNumber varchar(255),
	EmailAddress varchar(255),
	AddressID uniqueidentifier REFERENCES Addresses(ID),
	PRIMARY KEY(ID)
);

CREATE TABLE LibraryCards (
	UserID uniqueidentifier PRIMARY KEY REFERENCES Persons(ID) not null,
	RentedBooks int not null,
	CreationDate datetime not null
);

CREATE TABLE Students(
	PersonID uniqueidentifier PRIMARY KEY REFERENCES Persons(ID) not null,
	StudentID int unique not null,
	AverageMark float(2)
);

CREATE TABLE Teachers (
	PersonID Uniqueidentifier PRIMARY KEY REFERENCES Persons(ID) not null,
	TeacherID int unique not null,
	Salary FLOAT(3)
);

CREATE TABLE Grades(
	GradeID Uniqueidentifier primary key not null,
	Subject varchar(255) not null,
	Value float(2) not null
);

CREATE TABLE Courses (
	CourseID Uniqueidentifier primary key  not null,
	Name varchar(255) not null
);

CREATE TABLE StudentCourses(
	StudentID int FOREIGN KEY REFERENCES Students(StudentID) not null,
	CourseID Uniqueidentifier FOREIGN KEY REFERENCES Courses(CourseID) not null,
	PRIMARY KEY (StudentID, CourseID)
);

CREATE TABLE StudentGrades(
	StudentID int FOREIGN KEY REFERENCES Students(StudentID) not null,
	GradeID Uniqueidentifier FOREIGN KEY REFERENCES Grades(GradeID) not null,
	PRIMARY KEY (StudentID, GradeID)
);

CREATE TABLE TeacherCourses(
	TeacherID int REFERENCES Teachers(TeacherID) not null,
	CourseID Uniqueidentifier REFERENCES Courses(CourseID) not null,
	PRIMARY KEY (TeacherID, CourseID)
);