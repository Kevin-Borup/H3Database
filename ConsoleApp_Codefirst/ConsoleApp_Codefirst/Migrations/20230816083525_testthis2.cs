using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp_Codefirst.Migrations
{
    /// <inheritdoc />
    public partial class testthis2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Ids = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Streets = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    States = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zipcodes = table.Column<int>(type: "int", nullable: false),
                    Countries = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Ids);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Courseids = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coursenames = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Courseids);
                });

            migrationBuilder.CreateTable(
                name: "Librarycards",
                columns: table => new
                {
                    Userids = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rentedbooks = table.Column<int>(type: "int", nullable: false),
                    Creationdates = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarycards", x => x.Userids);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Ids = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Names = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phonenumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emailaddresses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addressids = table.Column<int>(type: "int", nullable: false),
                    Librarycarduserids = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_People_Addresses_Addressids",
                        column: x => x.Addressids,
                        principalTable: "Addresses",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_Librarycards_Librarycarduserids",
                        column: x => x.Librarycarduserids,
                        principalTable: "Librarycards",
                        principalColumn: "Userids");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Ids = table.Column<int>(type: "int", nullable: false),
                    Studentids = table.Column<int>(type: "int", nullable: false)
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
                    Teacherids = table.Column<int>(type: "int", nullable: false),
                    Subjects = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Coursestudents",
                columns: table => new
                {
                    Studentsids = table.Column<int>(type: "int", nullable: false),
                    Coursescourseids = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coursestudents", x => new { x.Studentsids, x.Coursescourseids });
                    table.ForeignKey(
                        name: "FK_Coursestudents_Courses_Coursescourseids",
                        column: x => x.Coursescourseids,
                        principalTable: "Courses",
                        principalColumn: "Courseids",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coursestudents_Students_Studentsids",
                        column: x => x.Studentsids,
                        principalTable: "Students",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Gradeids = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subjects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Values = table.Column<int>(type: "int", nullable: false),
                    Studentids = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Gradeids);
                    table.ForeignKey(
                        name: "FK_Grades_Students_Studentids",
                        column: x => x.Studentids,
                        principalTable: "Students",
                        principalColumn: "Ids");
                });

            migrationBuilder.CreateTable(
                name: "Courseteachers",
                columns: table => new
                {
                    Teachersids = table.Column<int>(type: "int", nullable: false),
                    Coursescourseids = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courseteachers", x => new { x.Teachersids, x.Coursescourseids });
                    table.ForeignKey(
                        name: "FK_Courseteachers_Courses_Coursescourseids",
                        column: x => x.Coursescourseids,
                        principalTable: "Courses",
                        principalColumn: "Courseids",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courseteachers_Teachers_Teachersids",
                        column: x => x.Teachersids,
                        principalTable: "Teachers",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GradeStudent",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    gradeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeStudent", x => new { x.StudentId, x.gradeID });
                    table.ForeignKey(
                        name: "FK_GradeStudent_Grades_gradeID",
                        column: x => x.gradeID,
                        principalTable: "Grades",
                        principalColumn: "Gradeids",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradeStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coursestudents_Coursescourseids",
                table: "Coursestudents",
                column: "Coursescourseids");

            migrationBuilder.CreateIndex(
                name: "IX_Courseteachers_Coursescourseids",
                table: "Courseteachers",
                column: "Coursescourseids");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Studentids",
                table: "Grades",
                column: "Studentids");

            migrationBuilder.CreateIndex(
                name: "IX_GradeStudent_gradeID",
                table: "GradeStudent",
                column: "gradeID");

            migrationBuilder.CreateIndex(
                name: "IX_People_Addressids",
                table: "People",
                column: "Addressids");

            migrationBuilder.CreateIndex(
                name: "IX_People_Librarycarduserids",
                table: "People",
                column: "Librarycarduserids");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coursestudents");

            migrationBuilder.DropTable(
                name: "Courseteachers");

            migrationBuilder.DropTable(
                name: "GradeStudent");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Librarycards");
        }
    }
}
