using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinFormsApp_DatabaseFirst.Migrations
{
    /// <inheritdoc />
    public partial class SchoolDbRingsted1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    State = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Addresse__3214EC27E9791045", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__C92D718750F193D9", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grades__54F87A379A37D90F", x => x.GradeID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Persons__3214EC272BB401AD", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Persons__Address__3B40CD36",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LibraryCards",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentedBooks = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LibraryC__1788CCACEB43875F", x => x.UserID);
                    table.ForeignKey(
                        name: "FK__LibraryCa__UserI__3E1D39E1",
                        column: x => x.UserID,
                        principalTable: "Persons",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    AverageMark = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__AA2FFB857813EE85", x => x.PersonID);
                    table.UniqueConstraint("AK_Students_StudentID", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK__Students__Person__41EDCAC5",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teachers__AA2FFB857D29BF98", x => x.PersonID);
                    table.UniqueConstraint("AK_Teachers_TeacherID", x => x.TeacherID);
                    table.ForeignKey(
                        name: "FK__Teachers__Person__45BE5BA9",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentC__5E57FD615B482283", x => new { x.StudentID, x.CourseID });
                    table.ForeignKey(
                        name: "FK__StudentCo__Cours__4D5F7D71",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__StudentCo__Stude__4C6B5938",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateTable(
                name: "StudentGrades",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    GradeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentG__578AADDA82164904", x => new { x.StudentID, x.GradeID });
                    table.ForeignKey(
                        name: "FK__StudentGr__Grade__51300E55",
                        column: x => x.GradeID,
                        principalTable: "Grades",
                        principalColumn: "GradeID");
                    table.ForeignKey(
                        name: "FK__StudentGr__Stude__503BEA1C",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeacherC__81608E5C724E541B", x => new { x.TeacherID, x.CourseID });
                    table.ForeignKey(
                        name: "FK__TeacherCo__Cours__55009F39",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__TeacherCo__Teach__540C7B00",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressID",
                table: "Persons",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseID",
                table: "StudentCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_GradeID",
                table: "StudentGrades",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "UQ__Students__32C52A78BF53C87A",
                table: "Students",
                column: "StudentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseID",
                table: "TeacherCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "UQ__Teachers__EDF25945DBF975D4",
                table: "Teachers",
                column: "TeacherID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryCards");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "StudentGrades");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
