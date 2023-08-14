
CREATE TABLE StudentGrades(
	StudentID int REFERENCES Students(StudentID),
	GradeID int REFERENCES Grades(GradeID),
	PRIMARY KEY (StudentID, GradeID)
);