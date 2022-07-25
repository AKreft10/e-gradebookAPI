using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_gradebookAPI.Migrations
{
    public partial class GradeYearNameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Grade_Year",
                table: "Students",
                newName: "GradeYear");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GradeYear",
                table: "Students",
                newName: "Grade_Year");
        }
    }
}
