using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admission.Migrations
{
    public partial class addGradetostudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentGrade",
                table: "Students",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentGrade",
                table: "Students");
        }
    }
}
