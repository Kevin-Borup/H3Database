CREATE TABLE Teachers (
	TeacherID int primary key,
	PersonID Uniqueidentifier,
	Salary FLOAT(3),
	CONSTRAINT pkfk_teachers_personID FOREIGN KEY (PersonID) REFERENCES Persons(ID)
);