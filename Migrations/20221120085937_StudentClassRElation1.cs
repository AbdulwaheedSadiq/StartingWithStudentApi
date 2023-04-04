using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsApi.Migrations
{
    public partial class StudentClassRElation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentClassId",
                table: "tblStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblStudents_StudentClassId",
                table: "tblStudents",
                column: "StudentClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblStudents_tblClasses_StudentClassId",
                table: "tblStudents",
                column: "StudentClassId",
                principalTable: "tblClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblStudents_tblClasses_StudentClassId",
                table: "tblStudents");

            migrationBuilder.DropIndex(
                name: "IX_tblStudents_StudentClassId",
                table: "tblStudents");

            migrationBuilder.DropColumn(
                name: "StudentClassId",
                table: "tblStudents");
        }
    }
}
