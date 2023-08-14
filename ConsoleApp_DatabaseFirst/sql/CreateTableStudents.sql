
CREATE TABLE Students(
	PersonID uniqueidentifier,
	StudentID int primary key,
	AverageMark float(2),
	CONSTRAINT pkfk_students_personID FOREIGN KEY (PersonID) REFERENCES Persons(ID)
);