using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Migrations
{
    public partial class StudentSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Students_StudentId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_StudentId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Subject");

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudentSubjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.StudentSubjectId);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_StudentId",
                table: "StudentSubject",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_StudentId",
                table: "Subject",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Students_StudentId",
                table: "Subject",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
