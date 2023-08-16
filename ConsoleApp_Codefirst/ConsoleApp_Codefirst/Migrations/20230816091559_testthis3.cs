using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp_Codefirst.Migrations
{
    /// <inheritdoc />
    public partial class testthis3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coursestudents_Courses_Coursescourseids",
                table: "Coursestudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Coursestudents_Students_Studentsids",
                table: "Coursestudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Courseteachers_Courses_Coursescourseids",
                table: "Courseteachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Courseteachers_Teachers_Teachersids",
                table: "Courseteachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_Studentids",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Addresses_Addressids",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Librarycards_Librarycarduserids",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Librarycards",
                table: "Librarycards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courseteachers",
                table: "Courseteachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coursestudents",
                table: "Coursestudents");

            migrationBuilder.RenameTable(
                name: "Librarycards",
                newName: "LibraryCards");

            migrationBuilder.RenameTable(
                name: "Courseteachers",
                newName: "CourseTeachers");

            migrationBuilder.RenameTable(
                name: "Coursestudents",
                newName: "CourseStudents");

            migrationBuilder.RenameColumn(
                name: "Teacherids",
                table: "Teachers",
                newName: "TeacherIDs");

            migrationBuilder.RenameColumn(
                name: "Subjects",
                table: "Teachers",
                newName: "subjects");

            migrationBuilder.RenameColumn(
                name: "Studentids",
                table: "Students",
                newName: "studentIDs");

            migrationBuilder.RenameColumn(
                name: "Phonenumbers",
                table: "People",
                newName: "PhoneNumbers");

            migrationBuilder.RenameColumn(
                name: "Librarycarduserids",
                table: "People",
                newName: "LibraryCardUserIds");

            migrationBuilder.RenameColumn(
                name: "Emailaddresses",
                table: "People",
                newName: "EmailAddresses");

            migrationBuilder.RenameColumn(
                name: "Addressids",
                table: "People",
                newName: "AddressIDs");

            migrationBuilder.RenameIndex(
                name: "IX_People_Librarycarduserids",
                table: "People",
                newName: "IX_People_LibraryCardUserIds");

            migrationBuilder.RenameIndex(
                name: "IX_People_Addressids",
                table: "People",
                newName: "IX_People_AddressIDs");

            migrationBuilder.RenameColumn(
                name: "Rentedbooks",
                table: "LibraryCards",
                newName: "RentedBooks");

            migrationBuilder.RenameColumn(
                name: "Creationdates",
                table: "LibraryCards",
                newName: "CreationDates");

            migrationBuilder.RenameColumn(
                name: "Userids",
                table: "LibraryCards",
                newName: "UserIds");

            migrationBuilder.RenameColumn(
                name: "Values",
                table: "Grades",
                newName: "values");

            migrationBuilder.RenameColumn(
                name: "Subjects",
                table: "Grades",
                newName: "subjects");

            migrationBuilder.RenameColumn(
                name: "Studentids",
                table: "Grades",
                newName: "StudentIds");

            migrationBuilder.RenameColumn(
                name: "Gradeids",
                table: "Grades",
                newName: "gradeIDs");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_Studentids",
                table: "Grades",
                newName: "IX_Grades_StudentIds");

            migrationBuilder.RenameColumn(
                name: "Coursescourseids",
                table: "CourseTeachers",
                newName: "coursesCourseIDs");

            migrationBuilder.RenameColumn(
                name: "Teachersids",
                table: "CourseTeachers",
                newName: "TeachersIds");

            migrationBuilder.RenameIndex(
                name: "IX_Courseteachers_Coursescourseids",
                table: "CourseTeachers",
                newName: "IX_CourseTeachers_coursesCourseIDs");

            migrationBuilder.RenameColumn(
                name: "Coursescourseids",
                table: "CourseStudents",
                newName: "coursesCourseIDs");

            migrationBuilder.RenameColumn(
                name: "Studentsids",
                table: "CourseStudents",
                newName: "StudentsIds");

            migrationBuilder.RenameIndex(
                name: "IX_Coursestudents_Coursescourseids",
                table: "CourseStudents",
                newName: "IX_CourseStudents_coursesCourseIDs");

            migrationBuilder.RenameColumn(
                name: "Coursenames",
                table: "Courses",
                newName: "CourseNames");

            migrationBuilder.RenameColumn(
                name: "Courseids",
                table: "Courses",
                newName: "CourseIDs");

            migrationBuilder.RenameColumn(
                name: "Ids",
                table: "Addresses",
                newName: "IDs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryCards",
                table: "LibraryCards",
                column: "UserIds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTeachers",
                table: "CourseTeachers",
                columns: new[] { "TeachersIds", "coursesCourseIDs" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents",
                columns: new[] { "StudentsIds", "coursesCourseIDs" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Courses_coursesCourseIDs",
                table: "CourseStudents",
                column: "coursesCourseIDs",
                principalTable: "Courses",
                principalColumn: "CourseIDs",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Students_StudentsIds",
                table: "CourseStudents",
                column: "StudentsIds",
                principalTable: "Students",
                principalColumn: "Ids",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeachers_Courses_coursesCourseIDs",
                table: "CourseTeachers",
                column: "coursesCourseIDs",
                principalTable: "Courses",
                principalColumn: "CourseIDs",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeachers_Teachers_TeachersIds",
                table: "CourseTeachers",
                column: "TeachersIds",
                principalTable: "Teachers",
                principalColumn: "Ids",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentIds",
                table: "Grades",
                column: "StudentIds",
                principalTable: "Students",
                principalColumn: "Ids");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Addresses_AddressIDs",
                table: "People",
                column: "AddressIDs",
                principalTable: "Addresses",
                principalColumn: "IDs",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_LibraryCards_LibraryCardUserIds",
                table: "People",
                column: "LibraryCardUserIds",
                principalTable: "LibraryCards",
                principalColumn: "UserIds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Courses_coursesCourseIDs",
                table: "CourseStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Students_StudentsIds",
                table: "CourseStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeachers_Courses_coursesCourseIDs",
                table: "CourseTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeachers_Teachers_TeachersIds",
                table: "CourseTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentIds",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Addresses_AddressIDs",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_LibraryCards_LibraryCardUserIds",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryCards",
                table: "LibraryCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTeachers",
                table: "CourseTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents");

            migrationBuilder.RenameTable(
                name: "LibraryCards",
                newName: "Librarycards");

            migrationBuilder.RenameTable(
                name: "CourseTeachers",
                newName: "Courseteachers");

            migrationBuilder.RenameTable(
                name: "CourseStudents",
                newName: "Coursestudents");

            migrationBuilder.RenameColumn(
                name: "subjects",
                table: "Teachers",
                newName: "Subjects");

            migrationBuilder.RenameColumn(
                name: "TeacherIDs",
                table: "Teachers",
                newName: "Teacherids");

            migrationBuilder.RenameColumn(
                name: "studentIDs",
                table: "Students",
                newName: "Studentids");

            migrationBuilder.RenameColumn(
                name: "PhoneNumbers",
                table: "People",
                newName: "Phonenumbers");

            migrationBuilder.RenameColumn(
                name: "LibraryCardUserIds",
                table: "People",
                newName: "Librarycarduserids");

            migrationBuilder.RenameColumn(
                name: "EmailAddresses",
                table: "People",
                newName: "Emailaddresses");

            migrationBuilder.RenameColumn(
                name: "AddressIDs",
                table: "People",
                newName: "Addressids");

            migrationBuilder.RenameIndex(
                name: "IX_People_LibraryCardUserIds",
                table: "People",
                newName: "IX_People_Librarycarduserids");

            migrationBuilder.RenameIndex(
                name: "IX_People_AddressIDs",
                table: "People",
                newName: "IX_People_Addressids");

            migrationBuilder.RenameColumn(
                name: "RentedBooks",
                table: "Librarycards",
                newName: "Rentedbooks");

            migrationBuilder.RenameColumn(
                name: "CreationDates",
                table: "Librarycards",
                newName: "Creationdates");

            migrationBuilder.RenameColumn(
                name: "UserIds",
                table: "Librarycards",
                newName: "Userids");

            migrationBuilder.RenameColumn(
                name: "values",
                table: "Grades",
                newName: "Values");

            migrationBuilder.RenameColumn(
                name: "subjects",
                table: "Grades",
                newName: "Subjects");

            migrationBuilder.RenameColumn(
                name: "StudentIds",
                table: "Grades",
                newName: "Studentids");

            migrationBuilder.RenameColumn(
                name: "gradeIDs",
                table: "Grades",
                newName: "Gradeids");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_StudentIds",
                table: "Grades",
                newName: "IX_Grades_Studentids");

            migrationBuilder.RenameColumn(
                name: "coursesCourseIDs",
                table: "Courseteachers",
                newName: "Coursescourseids");

            migrationBuilder.RenameColumn(
                name: "TeachersIds",
                table: "Courseteachers",
                newName: "Teachersids");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTeachers_coursesCourseIDs",
                table: "Courseteachers",
                newName: "IX_Courseteachers_Coursescourseids");

            migrationBuilder.RenameColumn(
                name: "coursesCourseIDs",
                table: "Coursestudents",
                newName: "Coursescourseids");

            migrationBuilder.RenameColumn(
                name: "StudentsIds",
                table: "Coursestudents",
                newName: "Studentsids");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudents_coursesCourseIDs",
                table: "Coursestudents",
                newName: "IX_Coursestudents_Coursescourseids");

            migrationBuilder.RenameColumn(
                name: "CourseNames",
                table: "Courses",
                newName: "Coursenames");

            migrationBuilder.RenameColumn(
                name: "CourseIDs",
                table: "Courses",
                newName: "Courseids");

            migrationBuilder.RenameColumn(
                name: "IDs",
                table: "Addresses",
                newName: "Ids");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Librarycards",
                table: "Librarycards",
                column: "Userids");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courseteachers",
                table: "Courseteachers",
                columns: new[] { "Teachersids", "Coursescourseids" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coursestudents",
                table: "Coursestudents",
                columns: new[] { "Studentsids", "Coursescourseids" });

            migrationBuilder.AddForeignKey(
                name: "FK_Coursestudents_Courses_Coursescourseids",
                table: "Coursestudents",
                column: "Coursescourseids",
                principalTable: "Courses",
                principalColumn: "Courseids",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coursestudents_Students_Studentsids",
                table: "Coursestudents",
                column: "Studentsids",
                principalTable: "Students",
                principalColumn: "Ids",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courseteachers_Courses_Coursescourseids",
                table: "Courseteachers",
                column: "Coursescourseids",
                principalTable: "Courses",
                principalColumn: "Courseids",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courseteachers_Teachers_Teachersids",
                table: "Courseteachers",
                column: "Teachersids",
                principalTable: "Teachers",
                principalColumn: "Ids",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_Studentids",
                table: "Grades",
                column: "Studentids",
                principalTable: "Students",
                principalColumn: "Ids");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Addresses_Addressids",
                table: "People",
                column: "Addressids",
                principalTable: "Addresses",
                principalColumn: "Ids",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Librarycards_Librarycarduserids",
                table: "People",
                column: "Librarycarduserids",
                principalTable: "Librarycards",
                principalColumn: "Userids");
        }
    }
}
