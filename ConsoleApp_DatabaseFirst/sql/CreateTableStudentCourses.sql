CREATE TABLE StudentCourses(
	CourseID int REFERENCES Courses(CourseID),
	StudentID int REFERENCES Students(StudentID),
);