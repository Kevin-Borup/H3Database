DROP TABLE TeacherCourses

CREATE TABLE TeacherCourses(
	CourseID int REFERENCES Courses(CourseID),
	TeacherID int REFERENCES Teachers(TeacherID),
);