using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp_Codefirst.Migrations
{
    /// <inheritdoc />
    public partial class testthis4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_GradeStudent_Students_StudentId",
                table: "GradeStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Addresses_AddressIDs",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_LibraryCards_LibraryCardUserIds",
                table: "People");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTeachers",
                table: "CourseTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents");

            migrationBuilder.RenameTable(
                name: "CourseTeachers",
                newName: "CourseTeacher");

            migrationBuilder.RenameTable(
                name: "CourseStudents",
                newName: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "PhoneNumbers",
                table: "People",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Names",
                table: "People",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LibraryCardUserIds",
                table: "People",
                newName: "LibraryCardUserId");

            migrationBuilder.RenameColumn(
                name: "EmailAddresses",
                table: "People",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "AddressIDs",
                table: "People",
                newName: "AddressID");

            migrationBuilder.RenameColumn(
                name: "Ids",
                table: "People",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_People_LibraryCardUserIds",
                table: "People",
                newName: "IX_People_LibraryCardUserId");

            migrationBuilder.RenameIndex(
                name: "IX_People_AddressIDs",
                table: "People",
                newName: "IX_People_AddressID");

            migrationBuilder.RenameColumn(
                name: "CreationDates",
                table: "LibraryCards",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "UserIds",
                table: "LibraryCards",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "values",
                table: "Grades",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "subjects",
                table: "Grades",
                newName: "subject");

            migrationBuilder.RenameColumn(
                name: "StudentIds",
                table: "Grades",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "gradeIDs",
                table: "Grades",
                newName: "gradeID");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_StudentIds",
                table: "Grades",
                newName: "IX_Grades_StudentId");

            migrationBuilder.RenameColumn(
                name: "CourseNames",
                table: "Courses",
                newName: "CourseName");

            migrationBuilder.RenameColumn(
                name: "CourseIDs",
                table: "Courses",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "Zipcodes",
                table: "Addresses",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "Streets",
                table: "Addresses",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "States",
                table: "Addresses",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Countries",
                table: "Addresses",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Cities",
                table: "Addresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "IDs",
                table: "Addresses",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "coursesCourseIDs",
                table: "CourseTeacher",
                newName: "coursesCourseID");

            migrationBuilder.RenameColumn(
                name: "TeachersIds",
                table: "CourseTeacher",
                newName: "TeachersId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTeachers_coursesCourseIDs",
                table: "CourseTeacher",
                newName: "IX_CourseTeacher_coursesCourseID");

            migrationBuilder.RenameColumn(
                name: "coursesCourseIDs",
                table: "CourseStudent",
                newName: "coursesCourseID");

            migrationBuilder.RenameColumn(
                name: "StudentsIds",
                table: "CourseStudent",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudents_coursesCourseIDs",
                table: "CourseStudent",
                newName: "IX_CourseStudent_coursesCourseID");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "studentID",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "subject",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTeacher",
                table: "CourseTeacher",
                columns: new[] { "TeachersId", "coursesCourseID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent",
                columns: new[] { "StudentsId", "coursesCourseID" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_coursesCourseID",
                table: "CourseStudent",
                column: "coursesCourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_People_StudentsId",
                table: "CourseStudent",
                column: "StudentsId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeacher_Courses_coursesCourseID",
                table: "CourseTeacher",
                column: "coursesCourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeacher_People_TeachersId",
                table: "CourseTeacher",
                column: "TeachersId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_People_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeStudent_People_StudentId",
                table: "GradeStudent",
                column: "StudentId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Addresses_AddressID",
                table: "People",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_LibraryCards_LibraryCardUserId",
                table: "People",
                column: "LibraryCardUserId",
                principalTable: "LibraryCards",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_coursesCourseID",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_People_StudentsId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeacher_Courses_coursesCourseID",
                table: "CourseTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeacher_People_TeachersId",
                table: "CourseTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_People_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeStudent_People_StudentId",
                table: "GradeStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Addresses_AddressID",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_LibraryCards_LibraryCardUserId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTeacher",
                table: "CourseTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "People");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "People");

            migrationBuilder.DropColumn(
                name: "studentID",
                table: "People");

            migrationBuilder.DropColumn(
                name: "subject",
                table: "People");

            migrationBuilder.RenameTable(
                name: "CourseTeacher",
                newName: "CourseTeachers");

            migrationBuilder.RenameTable(
                name: "CourseStudent",
                newName: "CourseStudents");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "People",
                newName: "PhoneNumbers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "People",
                newName: "Names");

            migrationBuilder.RenameColumn(
                name: "LibraryCardUserId",
                table: "People",
                newName: "LibraryCardUserIds");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "People",
                newName: "EmailAddresses");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "People",
                newName: "AddressIDs");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "People",
                newName: "Ids");

            migrationBuilder.RenameIndex(
                name: "IX_People_LibraryCardUserId",
                table: "People",
                newName: "IX_People_LibraryCardUserIds");

            migrationBuilder.RenameIndex(
                name: "IX_People_AddressID",
                table: "People",
                newName: "IX_People_AddressIDs");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "LibraryCards",
                newName: "CreationDates");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LibraryCards",
                newName: "UserIds");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "Grades",
                newName: "values");

            migrationBuilder.RenameColumn(
                name: "subject",
                table: "Grades",
                newName: "subjects");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Grades",
                newName: "StudentIds");

            migrationBuilder.RenameColumn(
                name: "gradeID",
                table: "Grades",
                newName: "gradeIDs");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                newName: "IX_Grades_StudentIds");

            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "Courses",
                newName: "CourseNames");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Courses",
                newName: "CourseIDs");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "Addresses",
                newName: "Zipcodes");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Addresses",
                newName: "Streets");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Addresses",
                newName: "States");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Addresses",
                newName: "Countries");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Addresses",
                newName: "Cities");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Addresses",
                newName: "IDs");

            migrationBuilder.RenameColumn(
                name: "coursesCourseID",
                table: "CourseTeachers",
                newName: "coursesCourseIDs");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "CourseTeachers",
                newName: "TeachersIds");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTeacher_coursesCourseID",
                table: "CourseTeachers",
                newName: "IX_CourseTeachers_coursesCourseIDs");

            migrationBuilder.RenameColumn(
                name: "coursesCourseID",
                table: "CourseStudents",
                newName: "coursesCourseIDs");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "CourseStudents",
                newName: "StudentsIds");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_coursesCourseID",
                table: "CourseStudents",
                newName: "IX_CourseStudents_coursesCourseIDs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTeachers",
                table: "CourseTeachers",
                columns: new[] { "TeachersIds", "coursesCourseIDs" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents",
                columns: new[] { "StudentsIds", "coursesCourseIDs" });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Ids = table.Column<int>(type: "int", nullable: false),
                    studentIDs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_Students_People_Ids",
                        column: x => x.Ids,
                        principalTable: "People",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Ids = table.Column<int>(type: "int", nullable: false),
                    TeacherIDs = table.Column<int>(type: "int", nullable: false),
                    subjects = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_Teachers_People_Ids",
                        column: x => x.Ids,
                        principalTable: "People",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "FK_GradeStudent_Students_StudentId",
                table: "GradeStudent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Ids",
                onDelete: ReferentialAction.Cascade);

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
    }
}
