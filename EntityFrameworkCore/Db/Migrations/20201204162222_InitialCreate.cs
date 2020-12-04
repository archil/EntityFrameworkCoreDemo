using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningManagementSystem.Db.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Name" },
                values: new object[,]
                {
                    { 1, "Student 1" },
                    { 29, "Student 29" },
                    { 30, "Student 30" },
                    { 31, "Student 31" },
                    { 32, "Student 32" },
                    { 33, "Student 33" },
                    { 34, "Student 34" },
                    { 35, "Student 35" },
                    { 36, "Student 36" },
                    { 37, "Student 37" },
                    { 38, "Student 38" },
                    { 27, "Student 27" },
                    { 39, "Student 39" },
                    { 41, "Student 41" },
                    { 42, "Student 42" },
                    { 43, "Student 43" },
                    { 44, "Student 44" },
                    { 45, "Student 45" },
                    { 46, "Student 46" },
                    { 47, "Student 47" },
                    { 48, "Student 48" },
                    { 49, "Student 49" },
                    { 50, "Student 50" },
                    { 40, "Student 40" },
                    { 26, "Student 26" },
                    { 28, "Student 28" },
                    { 24, "Student 24" },
                    { 2, "Student 2" },
                    { 3, "Student 3" },
                    { 4, "Student 4" },
                    { 5, "Student 5" },
                    { 6, "Student 6" },
                    { 7, "Student 7" },
                    { 8, "Student 8" },
                    { 9, "Student 9" },
                    { 10, "Student 10" },
                    { 25, "Student 25" },
                    { 12, "Student 12" },
                    { 11, "Student 11" },
                    { 14, "Student 14" },
                    { 15, "Student 15" },
                    { 16, "Student 16" },
                    { 17, "Student 17" },
                    { 18, "Student 18" },
                    { 19, "Student 19" },
                    { 20, "Student 20" },
                    { 21, "Student 21" },
                    { 22, "Student 22" },
                    { 23, "Student 23" },
                    { 13, "Student 13" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "SubjectId", "Name" },
                values: new object[,]
                {
                    { 4, "Subject 4" },
                    { 1, "Subject 1" },
                    { 2, "Subject 2" },
                    { 3, "Subject 3" },
                    { 5, "Subject 5" }
                });

            migrationBuilder.InsertData(
                table: "StudentSubject",
                columns: new[] { "StudentId", "SubjectId", "Score" },
                values: new object[,]
                {
                    { 4, 1, null },
                    { 49, 4, null },
                    { 42, 4, null },
                    { 40, 4, null },
                    { 38, 4, null },
                    { 31, 4, null },
                    { 29, 4, null },
                    { 27, 4, null },
                    { 23, 4, null },
                    { 19, 4, null },
                    { 18, 4, null },
                    { 17, 4, null },
                    { 14, 4, null },
                    { 13, 4, null },
                    { 9, 4, null },
                    { 8, 4, null },
                    { 7, 4, null },
                    { 6, 4, null },
                    { 49, 3, null },
                    { 48, 3, null },
                    { 47, 3, null },
                    { 41, 3, null },
                    { 50, 4, null },
                    { 36, 3, null },
                    { 1, 5, null },
                    { 4, 5, null },
                    { 44, 5, null },
                    { 43, 5, null },
                    { 42, 5, null },
                    { 39, 5, null },
                    { 38, 5, null },
                    { 35, 5, null },
                    { 33, 5, null },
                    { 30, 5, null },
                    { 26, 5, null },
                    { 24, 5, null },
                    { 23, 5, null },
                    { 22, 5, null },
                    { 21, 5, null },
                    { 20, 5, null },
                    { 19, 5, null },
                    { 15, 5, null },
                    { 14, 5, null },
                    { 12, 5, null },
                    { 11, 5, null },
                    { 7, 5, null },
                    { 5, 5, null },
                    { 2, 5, null },
                    { 30, 3, null },
                    { 29, 3, null },
                    { 28, 3, null },
                    { 24, 2, null },
                    { 17, 2, null },
                    { 16, 2, null },
                    { 15, 2, null },
                    { 12, 2, null },
                    { 10, 2, null },
                    { 3, 2, null },
                    { 48, 1, null },
                    { 46, 1, null },
                    { 45, 1, null },
                    { 43, 1, null },
                    { 37, 1, null },
                    { 36, 1, null },
                    { 34, 1, null },
                    { 32, 1, null },
                    { 31, 1, null },
                    { 28, 1, null },
                    { 13, 1, null },
                    { 10, 1, null },
                    { 9, 1, null },
                    { 6, 1, null },
                    { 25, 2, null },
                    { 32, 2, null },
                    { 33, 2, null },
                    { 34, 2, null },
                    { 27, 3, null },
                    { 26, 3, null },
                    { 25, 3, null },
                    { 22, 3, null },
                    { 21, 3, null },
                    { 20, 3, null },
                    { 18, 3, null },
                    { 16, 3, null },
                    { 11, 3, null },
                    { 8, 3, null },
                    { 46, 5, null },
                    { 5, 3, null },
                    { 2, 3, null },
                    { 1, 3, null },
                    { 47, 2, null },
                    { 45, 2, null },
                    { 44, 2, null },
                    { 41, 2, null },
                    { 40, 2, null },
                    { 39, 2, null },
                    { 37, 2, null },
                    { 35, 2, null },
                    { 3, 3, null },
                    { 50, 5, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
